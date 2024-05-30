using System.ComponentModel.DataAnnotations;
using System.Data;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage
{
    [OSInterface(
        Name = "AWSSimpleStorage",
        Description = "Amazon Simple Storage Service (Amazon S3) is an object storage service that offers industry-leading scalability, data availability, security, and performance",
        IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
    public interface ISimpleStorage
    {
        [OSAction(Description = "Retrieves an object from Amazon S3",
            ReturnName = "result",
            ReturnDescription = "Retrieved S3 object details",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        Structures.GetObjectResponse GetObject(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "GetObject Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.GetObjectRequest getObjectRequest);

        [OSAction(Description = "Delete an Amazon S3 Bucket",
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        void DeleteBucket(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "DeleteBucket Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.DeleteBucketRequest deleteBucketRequest);
        
        [OSAction(Description = "List Amazon S3 Buckets",
            ReturnName = "result",
            ReturnDescription = "ListBuckets result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        Structures.ListBucketsResponse ListBuckets(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region);

        [OSAction(Description = "Create an Amazon S3 Bucket",
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        void PutBucket(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "PutBucket Request Parameters")]
            Structures.PutBucketRequest putBucketRequest);

        [OSAction(Description = "List Objects of an Amazon S3 Bucket",
            ReturnName = "result",
            ReturnDescription = "Object results",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        Structures.ListObjectsResponse ListObjects(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "ListObjects Request Parameters")]
            Structures.ListObjectsRequest listObjectsRequest);

        [OSAction(Description = "Puts an object in an Amazon S3 Bucket",
            ReturnName = "result",
            ReturnDescription = "PutObject result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        Structures.PutObjectResponse PutObject(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "PutObject Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.PutObjectRequest putObjectRequest);

        [OSAction(Description = "Deletes an object in an Amazon S3 Bucket",
            ReturnName = "result",
            ReturnDescription = "DeleteObject result",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        Structures.DeleteObjectResponse DeleteObject(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "DeleteObject Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.DeleteObjectRequest deleteObjectRequest);

        [OSAction(Description = "Generates a pre-signed URL for an Amazon S3 object",
            ReturnName = "url",
            ReturnDescription = "pre-signed url to existing or new object",
            ReturnType = OSDataType.Text,
            IconResourceName = "Without.Systems.SimpleStorage.Resources.SimpleStorage.png")]
        string GetPresignedUrl(
            [OSParameter(
                Description = "AWS Account Credentials",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Credentials credentials,
            [OSParameter(
                Description = "AWS Region",
                DataType = OSDataType.Text)]
            string region,
            [OSParameter(
                Description = "GetPreSignedUrl Request Parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.GetPreSignedUrlRequest getPreSignedUrlRequest);
    }
}