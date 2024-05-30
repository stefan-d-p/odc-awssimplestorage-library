using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Put Object to Amazon S3 Bucket")]
public struct PutObjectRequest
{
    [OSStructureField(Description = "The bucket name to which the PUT action was initiated",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;
    
    [OSStructureField(Description = "This is a convenience property for Headers.ContentType",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContentType;
    
    [OSStructureField(Description = "This key is used to identify the object in S3",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;

    [OSStructureField(Description = "The collection of meta data for the request",
        IsMandatory = false)]
    public List<ObjectMetadata> Metadata;
    
    [OSStructureField(Description = "Storage class of object. Default is STANDARD",
        DataType = OSDataType.Text,
        IsMandatory = true,
        DefaultValue = "STANDARD")]
    public string StorageClass;

    [OSStructureField(Description = "he tag-set for the object",
        IsMandatory = false)]
    public List<Tag> TagSet;
    
    [OSStructureField(Description = "Content of the object as binary data",
        DataType = OSDataType.BinaryData,
        IsMandatory = false)]
    public byte[] Data;

    [OSStructureField(
        Description = "Text content to be uploaded. Use this property if you want to upload plaintext to S3",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContentBody;

    [OSStructureField(Description = "Collection of additional headers",
        IsMandatory = false)]
    public HeadersCollection Headers;


}
