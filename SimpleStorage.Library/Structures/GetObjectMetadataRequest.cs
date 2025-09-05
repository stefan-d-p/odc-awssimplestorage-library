using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Get ObjectMetadata Request Structure")]
public struct GetObjectMetadataRequest
{
    [OSStructureField(Description = "The bucket name containing the object.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;
    
    [OSStructureField(Description = "ETag to be matched as a pre-condition for returning the object, otherwise a PreconditionFailed signal is returned.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? EtagToMatch;
    
    [OSStructureField(
        Description =
            "The account ID of the expected bucket owner. If the account ID that you provide does not match the actual owner of the bucket, the request fails with the HTTP status code",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? ExpectedBucketOwner;
    
    [OSStructureField(Description = "Gets and sets the Key property. This is the user defined key that identifies the object in the bucket",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;
    
    [OSStructureField(Description = "Returns the object only if it has been modified since the specified time, otherwise returns a PreconditionFailed",
        DataType = OSDataType.DateTime,
        IsMandatory = false)]
    public DateTime? ModifiedSinceDateUtc;
    
    [OSStructureField(
        Description =
            "Returns the object only if it has not been modified since the specified time, otherwise returns a PreconditionFailed",
        DataType = OSDataType.DateTime,
        IsMandatory = false)]
    public DateTime? UnmodifiedSinceDateUtc;
    
    [OSStructureField(Description = "VersionId used to reference a specific version of the object",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string? VersionId;
}