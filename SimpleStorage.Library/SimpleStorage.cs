﻿using System.Net;
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
            
            /*
             * Response Mappings
             */

            cfg.CreateMap<Amazon.S3.Model.GetObjectResponse, Structures.GetObjectResponse>()
                .ForMember(dest => dest.Headers,
                    opt => opt.MapFrom(src => src.Headers.Keys.Select(key => new Structures.ObjectHeader
                        { Name = key, Value = src.Headers[key] }).ToList()))
                .ForMember(dest => dest.Metadata,
                    opt => opt.MapFrom(src => src.Metadata.Keys.Select(key => new Structures.ObjectMetadata
                        { Name = key, Value = src.Metadata[key] }).ToList()));

            cfg.CreateMap<Amazon.S3.Model.ListBucketsResponse, Structures.ListBucketsResponse>();
            
            /*
             * Individual Mappings
             */

            cfg.CreateMap<Amazon.S3.Model.Expiration, Structures.Expiration>();
            cfg.CreateMap<Amazon.S3.Model.Owner, Structures.Owner>();
            cfg.CreateMap<Amazon.S3.Model.S3Bucket, Structures.S3Bucket>();
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

    private AmazonS3Client GetAwsSimpleStorageClient(Structures.Credentials credentials, string region) =>
        new AmazonS3Client(credentials.ToAwsCredentials(), RegionEndpoint.GetBySystemName(region));

    private void ParseResponse(AmazonWebServiceResponse response)
    {
        if (!(response.HttpStatusCode.Equals(HttpStatusCode.OK) || response.HttpStatusCode.Equals(HttpStatusCode.NoContent)))
            throw new Exception($"Error in operation ({response.HttpStatusCode})");
    }
}