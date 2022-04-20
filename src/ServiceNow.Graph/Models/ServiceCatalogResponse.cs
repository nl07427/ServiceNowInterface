using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// CatalogResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ServiceCatalogResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="ServiceCatalog"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public ServiceCatalog Result { get; set; }
    }
}
