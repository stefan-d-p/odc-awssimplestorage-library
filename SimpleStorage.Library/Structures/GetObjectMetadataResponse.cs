using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(
    Description = "Response from GetObjectMetadata operation")]
public struct GetObjectMetadataResponse
{
    [OSStructureField(Description = "The date and time at which the object is no longer cacheable",
        DataType = OSDataType.Text)]
    public string ExpiresString;
    
    [OSStructureField(Description = "The collection of headers for the request")]
    public HeadersCollection Headers;

    [OSStructureField(Description = "The collection of meta data for the request")]
    public List<ObjectMetadata> Metadata;
}