using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type LocationResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class LocationResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Location"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public Location Result { get; set; }
    }
}
