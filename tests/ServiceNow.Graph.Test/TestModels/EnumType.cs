using System.Text.Json.Serialization;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// Enum for testing enum serialization and deserialization.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EnumType
    {
        Value,
    }
}
