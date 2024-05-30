using System.ComponentModel.DataAnnotations;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Generate a presigned url request")]
public struct GetPreSignedUrlRequest
{
    [OSStructureField(Description = "The name of the bucket to create a pre-signed url to, or containing the object",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string BucketName;
    
    [OSStructureField(Description = "The key to the object for which a pre-signed url should be created",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Key;
    
    [OSStructureField(Description = "A standard MIME type describing the format of the object data",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ContentType;

    [OSStructureField(Description = "The expiry date and time for the pre-signed url",
        DataType = OSDataType.DateTime,
        IsMandatory = false)]
    public DateTime Expires;
    
    [OSStructureField(Description = "The verb for the pre-signed url: GET, PUT, DELETE and HEAD, Default is GET",
        DataType = OSDataType.Text,
        IsMandatory = false,
        DefaultValue = "GET")]
    public string Verb;
    
    [OSStructureField(Description = "Version id for the object that the pre-signed url will reference",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string VersionId;

    [OSStructureField(Description = "The collection of headers for the request",
        IsMandatory = false)]
    public HeadersCollection Headers;

    [OSStructureField(Description = "The collection of meta data for the request",
        IsMandatory = false)]
    public List<ObjectMetadata> Metadata;
    
}