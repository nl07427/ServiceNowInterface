using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// CatalogItemResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogItemResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Question"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public CatalogItem Result { get; set; }
    }
}
