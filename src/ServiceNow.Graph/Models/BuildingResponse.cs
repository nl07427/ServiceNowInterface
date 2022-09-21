using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// BuildingResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BuildingResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Building"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public Building Result { get; set; }
    }
}
