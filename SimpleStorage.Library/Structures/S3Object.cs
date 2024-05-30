using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "S3 Object")]
public struct S3Object
{
    [OSStructureField(Description = "The algorithm that was used to create a checksum of the object")]
    public List<string> ChecksumAlgorithm;

    [OSStructureField(
        Description =
            "The entity tag is a hash of the object. The ETag reflects changes only to the contents of an object, not its metadata",
        DataType = OSDataType.Text)]
    public string ETag;

    [OSStructureField(Description = "he name of the bucket containing this object",
        DataType = OSDataType.Text)]
    public string BucketName;
    
    [OSStructureField(Description = "The key of the object",
        DataType = OSDataType.Text)]
    public string Key;
    
    [OSStructureField(Description = "Date and time when the object was last modified",
        DataType = OSDataType.DateTime)]
    public DateTime LastModified;
    
    [OSStructureField(Description = "The size of the object",
        DataType = OSDataType.LongInteger)]
    public long Size;
    
    [OSStructureField(Description = "The storage class of the object",
        DataType = OSDataType.Text)]
    public string StorageClass;
}