using System.ComponentModel.DataAnnotations;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "List S3 Objects")]
public struct ListObjectsRequest
{
    [OSStructureField(Description = "The name of the bucket containing the objects",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;
    
    [OSStructureField(Description = "A delimiter is a character that you use to group keys",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Delimiter;
    
    [OSStructureField(Description = "ContinuationToken indicates to Amazon S3 that the list is being continued on this bucket with a token. ContinuationToken is obfuscated and is not a real key. You can use this ContinuationToken for pagination of the list results",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContinuationToken;
    
    [OSStructureField(Description = " Sets the maximum number of keys returned in the response",
        DataType = OSDataType.Integer,
        IsMandatory = false)]
    public int MaxKeys;

    [OSStructureField(
        Description =
            "Specifies the optional fields that you want returned in the response. Fields that you do not specify are not returned",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public List<string> OptionalObjectAttributes;
    
    [OSStructureField(Description = "Prefix is where you want Amazon S3 to start listing from. Prefix can be any key in the bucket",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Prefix;
    
    [OSStructureField(Description = "StartAfter is where you want Amazon S3 to start listing from. Amazon S3 starts listing after this specified key. StartAfter can be any key in the bucket",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string StartAfter;
}