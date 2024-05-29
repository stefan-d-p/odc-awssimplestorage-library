using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Object Metadata Value Pair")]
public struct ObjectMetadata
{
    [OSStructureField(Description = "Metadata name")]
    public string Name;
    
    [OSStructureField(Description = "Metadata value")]
    public string Value;
}