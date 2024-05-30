using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Owner's display name and ID")]
public struct Owner
{
    [OSStructureField(Description = "Display Name",
        DataType = OSDataType.Text)]
    public string DisplayName;
    
    [OSStructureField(Description = "The unique identifier of the owner",
        DataType = OSDataType.Text)]
    public string Id;
}