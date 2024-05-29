using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Delete Bucket Request Parameters")]
public struct DeleteBucketRequest
{
    [OSStructureField(Description = "Specifies the bucket being deleted",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;
    
    [OSStructureField(Description = "When set, this will determine the region the bucket exists in",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string BucketRegion;
    
    [OSStructureField(Description = "If set to true the bucket will be deleted in the same region as the configuration of the AmazonS3 client. DeleteBucketRequest.BucketRegion takes precedence over this property if both are set.",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "true")]
    public bool? UseClientRegion;
}