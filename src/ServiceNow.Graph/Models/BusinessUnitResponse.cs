using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// BusinessUnitResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BusinessUnitResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="BusinessUnit"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public BusinessUnit Result { get; set; }
    }
}
