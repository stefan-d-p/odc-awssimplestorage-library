using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Delete S3 Object Request")]
public struct DeleteObjectRequest
{
    [OSStructureField(Description = "The bucket name of the bucket containing the object",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;
    
    [OSStructureField(Description = "Key name of the object to delete",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;
    
    [OSStructureField(Description = "The version ID of the object to delete",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string VersionId;
}