using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Returns information about the  ListBuckets response and response metadata")]
public struct ListBucketsResponse
{
    [OSStructureField(Description = "List of buckets")]
    public List<S3Bucket> Buckets;
    
    [OSStructureField(Description = "Owner of the buckets")]
    public Owner Owner;
}