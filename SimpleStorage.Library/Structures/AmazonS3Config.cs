using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Amazon S3 Client Configuration")]
public struct AmazonS3Config
{
    private string? _serviceUrl;
    
    
    [OSStructureField(Description = "When true, requests will always use path style addressing. Default is False.",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "False")]
    public bool ForcePathStyle;
    
    [OSStructureField(Description = "Gets and sets of the ProxyHost property",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ProxyHost;
    
    [OSStructureField(Description = "Gets and sets of the ProxyPort property",
        DataType = OSDataType.Integer,
        IsMandatory = false)]
    public int ProxyPort;
    
    [OSStructureField(Description = "Gets and sets the RegionEndpoint property.  The region constant that determines the endpoint to use.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string RegionEndpoint;
    
    [OSStructureField(Description = "Use OutSystems Secure Gateway. Set to true to use your ODC Private Gateway endpoint for connecting to a private instance of S3",
        DataType = OSDataType.Boolean,
        IsMandatory = false,
        DefaultValue = "False")]
    public bool UseSecureGateway;
    
    [OSStructureField(Description = "OutSystems Secure Gateway port number to connect",
        DataType = OSDataType.Integer,
        IsMandatory = false)]
    public int SecureGatewayPort;

    [OSStructureField(
        Description =
            "Gets and sets of the ServiceURL property. This is an optional property; change it only if you want to try a different service endpoint.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    // ReSharper disable once InconsistentNaming
    public string? ServiceURL
    {
        get
        {
            /*
             * When used with Private Gateway return the environment variable for private gateway
             */
            if (UseSecureGateway) return $"{Environment.GetEnvironmentVariable("SECURE_GATEWAY")}:{SecureGatewayPort}";
            
            return _serviceUrl;
        }
        // ReSharper disable once PropertyCanBeMadeInitOnly.Global
        set => _serviceUrl = value;
    }
    
    
    
}