using System.ComponentModel.DataAnnotations;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Headers Collection Structure")]
public struct HeadersCollection
{
    [OSStructureField(Description = "Specifies caching behavior along the request/reply chain",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string CacheControl;
    
    [OSStructureField(Description = "Specifies presentational information for the object",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContentDisposition;
    
    [OSStructureField(Description = "Specifies what content encodings have been applied to the object",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContentEncoding;
    
    [OSStructureField(Description = "Size of the body in bytes",
        DataType = OSDataType.LongInteger,
        IsMandatory = false)]
    public long ContentLength;
    
    [OSStructureField(Description = "A standard MIME type describing the format of the contents",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContentType;
    
       
}