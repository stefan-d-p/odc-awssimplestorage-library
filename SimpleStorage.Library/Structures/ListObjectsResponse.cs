using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "List Objects Result Structure")]
public struct ListObjectsResponse
{
    [OSStructureField(Description = "All of the keys (up to 1,000) that share the same prefix are grouped together",
        DataType = OSDataType.InferredFromDotNetType)]
    public List<string> CommonPrefixes;
    
    [OSStructureField(Description = "S3 Objects")]
    public List<S3Object> S3Objects;
    
    [OSStructureField(Description = "Continuation Token",
        DataType = OSDataType.Text)]
    public string ContinuationToken;
    
    [OSStructureField(Description = "Causes keys that contain the same string between the prefix and the first occurrence of the delimiter to be rolled up into a single result element in the CommonPrefixes collection. These rolled-up keys are not returned elsewhere in the response. Each rolled-up result counts as only one return against the MaxKeys value",
        DataType = OSDataType.Text)]
    public string Delimiter;
    
    [OSStructureField(Description = "Set to false if all of the results were returned",
        DataType = OSDataType.Boolean)]
    public bool IsTruncated;
    
    [OSStructureField(Description = "KeyCount is the number of keys returned with this request",
        DataType = OSDataType.Integer)]
    public int KeyCount;
    
    [OSStructureField(Description = "Sets the maximum number of keys returned in the response",
        DataType = OSDataType.Integer)]
    public int MaxKeys;
    
    [OSStructureField(Description = "The bucket name",
        DataType = OSDataType.Text)]
    public string Name;
    
    [OSStructureField(Description = "NextContinuationToken</code> is sent when IsTruncated is true, which means there are more keys in the bucket that can be listed",
        DataType = OSDataType.Text)]
    public string NextContinuationToken;

    [OSStructureField(Description = "Keys that begin with the indicated prefix",
        DataType = OSDataType.Text)]
    public string Prefix;
    
    [OSStructureField(Description = "If StartAfter was sent with the request, it is included in the response",
        DataType = OSDataType.Text)]
    public string StartAfter;

}