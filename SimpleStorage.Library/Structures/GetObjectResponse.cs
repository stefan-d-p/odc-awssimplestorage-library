using OutSystems.ExternalLibraries.SDK;
// ReSharper disable InconsistentNaming

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "GetObject Response Structure")]
public struct GetObjectResponse
{
    [OSStructureField(Description = "The date and time at which the object is no longer cacheable",
        DataType = OSDataType.Text)]
    public string ExpiresString;
    
    [OSStructureField(Description = "Gets and sets the BucketName property",
        DataType = OSDataType.Text)]
    public string BucketName;
    
    [OSStructureField(Description = "Gets and sets the Key property",
        DataType = OSDataType.Text)]
    public string Key;

    [OSStructureField(
        Description =
            "Specifies whether the object retrieved was (true) or was not (false) a Delete Marker. If false, this response header does not appear in the response",
        DataType = OSDataType.Text)]
    public string DeleteMarker;

    [OSStructureField(Description = "The collection of headers for the request")]
    public HeadersCollection Headers;

    [OSStructureField(Description = "The collection of meta data for the request")]
    public List<ObjectMetadata> Metadata;

    [OSStructureField(Description =
        "Gets and sets the Expiration property. Specifies the expiration date for the object and the rule governing the expiration. Is null if expiration is not applicable.")]
    public Expiration Expiration;

    [OSStructureField(Description = "Gets and sets the RestoreExpiration property",
        DataType = OSDataType.DateTime)]
    public DateTime? RestoreExpiration;
    
    [OSStructureField(Description = "Will be true when the object is in the process of being restored from Amazon Glacier",
        DataType = OSDataType.Boolean)]
    public bool RestoreInProgress;
    
    [OSStructureField(Description = "Date and time when the object was last modified",
        DataType = OSDataType.DateTime)]
    public DateTime LastModified;
    
    [OSStructureField(Description = "An ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL",
        DataType = OSDataType.Text)]
    public string ETag;
    
    [OSStructureField(Description = "Version ID of the object",
        DataType = OSDataType.Text)]
    public string VersionId;

    [OSStructureField(Description = "Provides storage class information of the object",
        DataType = OSDataType.Text)]
    public string StorageClass;
    
    [OSStructureField(Description = "The base64-encoded, 32-bit CRC32 checksum of the object",
        DataType = OSDataType.Text)]
    public string ChecksumCRC32;
    
    [OSStructureField(Description = "The base64-encoded, 160-bit SHA-1 digest of the object",
        DataType = OSDataType.Text)]
    public string ChecksumSHA1;
    
    [OSStructureField(Description = "The base64-encoded, 256-bit SHA-256 digest of the object",
        DataType = OSDataType.Text)]
    public string ChecksumSHA256;






}