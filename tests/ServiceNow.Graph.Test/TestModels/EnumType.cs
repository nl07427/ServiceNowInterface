using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// Enum for testing enum serialization and deserialization.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EnumType
    {
        Value,
    }
}
