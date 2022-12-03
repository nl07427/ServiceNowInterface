using Newtonsoft.Json.Converters;
using ServiceNow.Graph.Serialization;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// Enum for testing enum serialization and deserialization.
    /// </summary>
    [JsonConverter(typeof(EnumConverter))]
    [System.Flags]
    public enum EnumTypeWithFlags
    {
        FirstValue = 1,

        SecondValue = 2
    }
}
