using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Returns information about the PutObject response")]
public struct PutObjectResponse
{
    [OSStructureField(Description = "Entity tag for the uploaded object",
        DataType = OSDataType.Text)]
    public string ETag;
    
    [OSStructureField(Description = "Version ID of the object",
        DataType = OSDataType.Text)]
    public string VersionId;

}