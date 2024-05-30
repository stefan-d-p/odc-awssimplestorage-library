using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "An Amazon S3 bucket name is globally unique, and the namespace is shared by all Amazon Web Services accounts")]
public struct S3Bucket
{
    [OSStructureField(Description = "Date the bucket was created. This date can change when making changes to your bucket, such as editing its bucket policy.",
        DataType = OSDataType.DateTime)]
    public DateTime CreationDate;

    [OSStructureField(Description = "The name of the bucket.",
        DataType = OSDataType.Text)]
    public string BucketName;

}