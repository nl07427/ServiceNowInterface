using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ConfigurationItemResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ConfigurationItemResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Question"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public ConfigurationItem Result { get; set; }
    }
}
