using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using Without.Systems.SimpleStorage.Structures;
using GetObjectRequest = Without.Systems.SimpleStorage.Structures.GetObjectRequest;

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
}