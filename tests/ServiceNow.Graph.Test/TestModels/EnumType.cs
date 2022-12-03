using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// Enum for testing enum serialization and deserialization.
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    public enum EnumType
    {
        Value,
    }
}
