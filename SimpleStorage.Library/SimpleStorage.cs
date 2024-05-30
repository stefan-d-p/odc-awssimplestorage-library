using System.Net;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using AutoMapper;
using Without.Systems.SimpleStorage.Extensions;
using Without.Systems.SimpleStorage.Util;

namespace Without.Systems.SimpleStorage;

public class SimpleStorage : ISimpleStorage
{

    private readonly IMapper _mapper;
    
    public SimpleStorage()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            /*
             * Request Mappings
             */

            cfg.CreateMap<Structures.GetObjectRequest, Amazon.S3.Model.GetObjectRequest>()
                .ForMember(dest => dest.ModifiedSinceDateUtc,
                    opt => opt.Condition(src => src.ModifiedSinceDateUtc != new DateTime(1900, 1, 1)))
                .ForMember(dest => dest.UnmodifiedSinceDateUtc,
                    opt => opt.Condition(src => src.UnmodifiedSinceDateUtc != new DateTime(1900, 1, 1)))
                .ForMember(dest => dest.ExpectedBucketOwner,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.ExpectedBucketOwner)))
                .ForMember(dest => dest.VersionId, opt => opt.Condition(src => !string.IsNullOrEmpty(src.VersionId)))
                .ForMember(dest => dest.EtagToMatch,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.EtagToMatch)));

            cfg.CreateMap<Structures.DeleteBucketRequest, Amazon.S3.Model.DeleteBucketRequest>()
                .ForMember(dest => dest.BucketRegion,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.BucketRegion)))
                .ForMember(dest => dest.BucketRegion, opt => opt.MapFrom(src => S3Region.FindValue(src.BucketRegion)));

            cfg.CreateMap<Structures.PutBucketRequest, Amazon.S3.Model.PutBucketRequest>()
                .ForMember(dest => dest.BucketRegionName,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.BucketRegionName)));

            cfg.CreateMap<Structures.ListObjectsRequest, Amazon.S3.Model.ListObjectsV2Request>()
                .ForMember(dest => dest.Delimiter, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Delimiter)))
                .ForMember(dest => dest.ContinuationToken, opt => opt.Condition(src => !string.IsNullOrEmpty(src.ContinuationToken)))
                .ForMember(dest => dest.StartAfter, opt => opt.Condition(src => !string.IsNullOrEmpty(src.StartAfter)))
                .ForMember(dest => dest.MaxKeys, opt => opt.Condition(src => src.MaxKeys != 0))
                .ForMember(dest => dest.Prefix, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Prefix)))
                .ForMember(dest => dest.OptionalObjectAttributes,
                    opt => opt.Condition(src => src.OptionalObjectAttributes is { Count: > 0 }));

            cfg.CreateMap<Structures.PutObjectRequest, Amazon.S3.Model.PutObjectRequest>()
                .ForMember(dest => dest.ContentType,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.ContentType)))
                .ForMember(dest => dest.Metadata, opt => opt.Condition(src => src.Metadata is { Count: > 0 }))
                .ForMember(dest => dest.ContentBody,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.ContentBody)))
                .ForMember(dest => dest.InputStream, opt => opt.Condition(src => src.Data is { Length: > 0}))
                .ForMember(dest => dest.InputStream, opt => opt.MapFrom(src => new MemoryStream(src.Data)));
            
            /*
             * Response Mappings
             */

            cfg.CreateMap<Amazon.S3.Model.GetObjectResponse, Structures.GetObjectResponse>()
                .ForMember(dest => dest.Metadata,
                    opt => opt.MapFrom(src => src.Metadata.Keys.Select(key => new Structures.ObjectMetadata
                        { Name = key, Value = src.Metadata[key] }).ToList()));

            cfg.CreateMap<Amazon.S3.Model.ListBucketsResponse, Structures.ListBucketsResponse>();
            cfg.CreateMap<Amazon.S3.Model.ListObjectsV2Response, Structures.ListObjectsResponse>();
            cfg.CreateMap<Amazon.S3.Model.PutObjectResponse, Structures.PutObjectResponse>();
            
            /*
             * Individual Mappings
             */

            cfg.CreateMap<Structures.Tag, Amazon.S3.Model.Tag>();
            cfg.CreateMap<Structures.HeadersCollection, Amazon.S3.Model.HeadersCollection>()
                .ForMember(dest => dest.ContentType,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.ContentType)))
                .ForMember(dest => dest.CacheControl,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.CacheControl)))
                .ForMember(dest => dest.ContentDisposition,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.ContentDisposition)))
                .ForMember(dest => dest.ContentEncoding,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.ContentEncoding)))
                .ForMember(dest => dest.ContentLength, opt => opt.Condition(src => src.ContentLength > 0));
            
            cfg.CreateMap<List<Structures.ObjectMetadata>, Amazon.S3.Model.MetadataCollection>()
                .ConvertUsing((src, dest) =>
                {
                    var metadata = new Amazon.S3.Model.MetadataCollection();
                    foreach (var item in src)
                    {
                        metadata.Add(item.Name, item.Value);
                    }

                    return metadata;
                });
                
            
            cfg.CreateMap<Amazon.S3.Model.Expiration, Structures.Expiration>();
            cfg.CreateMap<Amazon.S3.Model.Owner, Structures.Owner>();
            cfg.CreateMap<Amazon.S3.Model.S3Bucket, Structures.S3Bucket>();
            cfg.CreateMap<Amazon.S3.Model.S3Object, Structures.S3Object>();
            cfg.CreateMap<Amazon.S3.Model.HeadersCollection, Structures.HeadersCollection>();

        });

        _mapper = mapperConfiguration.CreateMapper();

    }

    /// <summary>
    /// Retrieves an object from Amazon S3
    /// </summary>
    /// <param name="credentials">AWS Credentials</param>
    /// <param name="region">AWS region system name</param>
    /// <param name="getObjectRequest">GetObject Request parameters</param>
    /// <returns>GetObject Response Structure</returns>
    public Structures.GetObjectResponse GetObject(Structures.Credentials credentials, string region,
        Structures.GetObjectRequest getObjectRequest)
    {
        AmazonS3Client client = GetAwsSimpleStorageClient(credentials, region);
        var request = _mapper.Map<Amazon.S3.Model.GetObjectRequest>(getObjectRequest);
        Amazon.S3.Model.GetObjectResponse response = AsyncUtil.RunSync(() => client.GetObjectAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.GetObjectResponse>(response);
    }

    /// <summary>
    /// Deletes an Amazon S3 bucket
    /// </summary>
    /// <param name="credentials">AWS Credentials</param>
    /// <param name="region">AWS region system name</param>
    /// <param name="deleteBucketRequest">DeleteBucket Request parameters</param>
    public void DeleteBucket(Structures.Credentials credentials, string region, Structures.DeleteBucketRequest deleteBucketRequest)
    {
        AmazonS3Client client = GetAwsSimpleStorageClient(credentials, region);
        var request = _mapper.Map<Amazon.S3.Model.DeleteBucketRequest>(deleteBucketRequest);
        Amazon.S3.Model.DeleteBucketResponse response = AsyncUtil.RunSync(() => client.DeleteBucketAsync(request));
        ParseResponse(response);
    }

    /// <summary>
    /// Lists Amazon S3 buckets
    /// </summary>
    /// <param name="credentials">AWS Credentials</param>
    /// <param name="region">AWS region system name</param>
    /// <returns>ListBuckets Response Structure</returns>
    public Structures.ListBucketsResponse ListBuckets(Structures.Credentials credentials, string region)
    {
        AmazonS3Client client = GetAwsSimpleStorageClient(credentials, region);
        Amazon.S3.Model.ListBucketsResponse response = AsyncUtil.RunSync(() => client.ListBucketsAsync());
        ParseResponse(response);
        return _mapper.Map<Structures.ListBucketsResponse>(response);
    }

    /// <summary>
    /// Creates an Amazon S3 bucket
    /// </summary>
    /// <param name="credentials">AWS Credentials</param>
    /// <param name="region">AWS region system name</param>
    /// <param name="putBucketRequest">PutBucket Request parameters</param>
    public void PutBucket(Structures.Credentials credentials, string region,
        Structures.PutBucketRequest putBucketRequest)
    {
        AmazonS3Client client = GetAwsSimpleStorageClient(credentials, region);
        var request = _mapper.Map<Amazon.S3.Model.PutBucketRequest>(putBucketRequest);
        Amazon.S3.Model.PutBucketResponse response = AsyncUtil.RunSync(() => client.PutBucketAsync(request));
        ParseResponse(response);
    }

    /// <summary>
    /// Lists objects in an Amazon S3 bucket
    /// </summary>
    /// <param name="credentials">AWS Credentials</param>
    /// <param name="region">AWS region system name</param>
    /// <param name="listObjectsRequest">ListObjects Request parameters</param>
    /// <returns>ListObjects Response Structure</returns>
    public Structures.ListObjectsResponse ListObjects(Structures.Credentials credentials, string region,
        Structures.ListObjectsRequest listObjectsRequest)
    {
        AmazonS3Client client = GetAwsSimpleStorageClient(credentials, region);
        var request = _mapper.Map<Amazon.S3.Model.ListObjectsV2Request>(listObjectsRequest);
        Amazon.S3.Model.ListObjectsV2Response response = AsyncUtil.RunSync(() => client.ListObjectsV2Async(request));
        ParseResponse(response);
        return _mapper.Map<Structures.ListObjectsResponse>(response);
    }
    
    /// <summary>
    /// Stores an object in Amazon S3
    /// </summary>
    /// <param name="credentials">AWS Credentials</param>
    /// <param name="region">AWS region system name</param>
    /// <param name="putObjectRequest">PutObject Request parameters</param>
    /// <returns>PutObject Response Structure</returns>
    public Structures.PutObjectResponse PutObject(Structures.Credentials credentials, string region, Structures.PutObjectRequest putObjectRequest)
    {
        AmazonS3Client client = GetAwsSimpleStorageClient(credentials, region);
        var request = _mapper.Map<Amazon.S3.Model.PutObjectRequest>(putObjectRequest);
        Amazon.S3.Model.PutObjectResponse response = AsyncUtil.RunSync(() => client.PutObjectAsync(request));
        ParseResponse(response);
        return _mapper.Map<Structures.PutObjectResponse>(response);
    }

    private AmazonS3Client GetAwsSimpleStorageClient(Structures.Credentials credentials, string region) =>
        new AmazonS3Client(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));

    private void ParseResponse(AmazonWebServiceResponse response)
    {
        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) || response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error in operation ({response.HttpStatusCode})");
    }
}