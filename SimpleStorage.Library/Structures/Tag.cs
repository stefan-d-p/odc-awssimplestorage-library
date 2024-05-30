using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Key value tag")]
public struct Tag
{
    [OSStructureField(Description = "Name of the object key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;
    
    [OSStructureField(Description = "Value of the object key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Value;
}