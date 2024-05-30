using Microsoft.Extensions.Configuration;
using Without.Systems.SimpleStorage.Structures;

namespace Without.Systems.SimpleStorage.Test;

public class Tests
{
    private static readonly ISimpleStorage _actions = new SimpleStorage();
    
    private Credentials _credentials;
    private readonly string _awsRegion = "eu-central-1";

    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();

        string awsAccessKey = configuration["AWSAccessKey"] ?? throw new InvalidOperationException();
        string awsSecretAccessKey = configuration["AWSSecretAccessKey"] ?? throw new InvalidOperationException();

        _credentials = new Credentials(awsAccessKey, awsSecretAccessKey);
        
    }

    [Test]
    public void GetObject()
    {
        string bucket = "osslides";
        string key = "2d9e49a3-786c-4fca-b822-443b1ebd6c8d/0679263c-c129-4600-9086-d71b7ac0bcc2.png";
        
        GetObjectRequest request = new GetObjectRequest()
        {
            BucketName = bucket,
            Key = key
        };

        var result = _actions.GetObject(_credentials, _awsRegion, request);
    }

    [Test]
    public void ListBuckets()
    {
        var result = _actions.ListBuckets(_credentials, _awsRegion);
    }
    
    [Test]
    public void ListObjects()
    {
        string bucket = "osslides";

        ListObjectsRequest listObjectsRequest = new ListObjectsRequest()
        {
            BucketName = bucket
        };

        var result = _actions.ListObjects(_credentials, _awsRegion, listObjectsRequest);
    }

    [Test]
    public void CreateAndDeleteBucket()
    {
        string bucketname = "odclientsampletest";
        
        PutBucketRequest putBucketRequest = new PutBucketRequest()
        {
            BucketName = bucketname,
            UseClientRegion = true
        };
        
        _actions.PutBucket(_credentials, _awsRegion, putBucketRequest);

        DeleteBucketRequest deleteBucketRequest = new DeleteBucketRequest()
        {
            BucketName = bucketname
        };
        
        _actions.DeleteBucket(_credentials, _awsRegion, deleteBucketRequest);
        
    }

    [Test]
    public void PutObjectBinaryToBucket()
    {
        string filePath = @"c:\dev\doc2.pdf";
        string key = "test/doc2.pdf";
        string bucket = "osslides";
        
        List<Tag> tags = new List<Tag>();
        tags.Add(new Tag() { Key = "project", Value = "odc"});
        
        List<ObjectMetadata> metadata = new List<ObjectMetadata>();
        metadata.Add(new ObjectMetadata() { Name = "meta1", Value = "data1"});

        PutObjectRequest request = new PutObjectRequest()
        {
            BucketName = bucket,
            Key = key,
            Data = File.ReadAllBytes(filePath),
            StorageClass = "STANDARD",
            TagSet = tags,
            Metadata = metadata
        };
        
        
        _actions.PutObject(_credentials, _awsRegion, request);
    }
}