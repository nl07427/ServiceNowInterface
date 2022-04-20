using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// CatalogTaskResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogTaskResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="CatalogTask"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public CatalogTask Result { get; set; }
    }
}
