using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type CatalogOptionsResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogOptionsResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="CatalogOption"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public CatalogOption Result { get; set; }
    }
}
