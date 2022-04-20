using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// OrderGuideResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OrderGuideResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="OrderGuide"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public OrderGuide Result { get; set; }
    }
}
