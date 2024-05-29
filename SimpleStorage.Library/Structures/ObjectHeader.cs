using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;


[OSStructure(Description = "S3 Object Header Value Pair")]
public struct ObjectHeader
{
    [OSStructureField(Description = "Header name",
        DataType = OSDataType.Text)]
    public string Name;
    
    [OSStructureField(Description = "Header value",
        DataType = OSDataType.Text)]
    public string Value;
}