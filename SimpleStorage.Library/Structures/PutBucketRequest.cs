using System.ComponentModel.DataAnnotations;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Creates a new S3 bucket")]
public struct PutBucketRequest
{
    [OSStructureField(
        Description =
            "If set to true the bucket will be created in the same region as the configuration of the AmazonS3 client",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "true")]
    public bool UseClientRegion;
    
    [OSStructureField(Description = "The name of the bucket to create",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;
    
    [OSStructureField(Description = "The bucket region locality expressed using the name of the region. When set, this will determine where your data will reside in S3",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string BucketRegionName;
}