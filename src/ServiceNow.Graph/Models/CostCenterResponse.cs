using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// CostCenterResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CostCenterResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="CostCenter"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public CostCenter Result { get; set; }
    }
}
