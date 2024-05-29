using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.SimpleStorage.Structures;

[OSStructure(Description = "Object Expiry")]
public struct Expiration
{
     [OSStructureField(Description = "The date and time for expiry.",
          DataType = OSDataType.DateTime)]
     public DateTime ExpiryDateUtc;
     
     [OSStructureField(Description = "Id of the configuration rule for this expiry.",
          DataType = OSDataType.Text)]
      public string RuleId;
}