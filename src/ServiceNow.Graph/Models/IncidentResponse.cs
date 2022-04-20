using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// IncidentResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class IncidentResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Incident"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public Incident Result { get; set; }
    }
}
