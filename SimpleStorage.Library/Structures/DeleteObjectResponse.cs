using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "DeleteObject Response")]
public struct DeleteObjectResponse
{
    [OSStructureField(Description = "Indicates whether the specified object version that was permanently deleted was (true) or was not (false) a delete marker before deletion",
        DataType = OSDataType.Text)]
    public string DeleteMarker;
    
    [OSStructureField(Description = "Returns the version ID of the delete marker created as a result of the DELETE operation",
        DataType = OSDataType.Text)]
    public string VersionId;
}