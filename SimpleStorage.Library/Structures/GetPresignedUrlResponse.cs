using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "GetPresignedUrl Response Structure")]
public struct GetPresignedUrlResponse
{
    [OSStructureField(Description = "Full generated presigned Url",
        DataType = OSDataType.Text)]
    public string Url;

    [OSStructureField(Description = "Base Url of the presigned Url",
        DataType = OSDataType.Text)]
    public string BaseUrl;
    
    [OSStructureField(Description = "Object Key referenced by the presigned Url",
        DataType = OSDataType.Text)]
    public string Key;

    [OSStructureField(Description = "Session Token when using temporary credentials",
        DataType = OSDataType.Text)]
    public string SecurityToken;
    
    [OSStructureField(Description = "Signature Alghorithm used. Is always AWS4-HMAC-SHA256",
        DataType = OSDataType.Text)]
    public string Algorithm;
    
    [OSStructureField(Description = "Signed Headers. Additional headers that are included in the signature and must be passed along with a request",
        DataType = OSDataType.Text)]
    public string SignedHeaders;

    [OSStructureField(Description = "The date used to create the signature in the Authorization header",
        DataType = OSDataType.Text)]
    public string Date;
    
    [OSStructureField(Description = "Offset in seconds when the presigned Url expires",
        DataType = OSDataType.Text)]
    public string Expires;
    
    [OSStructureField(Description = "Credential Scope",
        DataType = OSDataType.Text)]
    public string Credential;
    
    [OSStructureField(Description = "Hex encoded signature of the presigned Url",
        DataType = OSDataType.Text)]
    public string Signature;



}