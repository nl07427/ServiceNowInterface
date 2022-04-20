using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{   
    /// <summary>
     /// The type CatalogItemOptionMtomResponse.
     /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogItemOptionMtomResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="CatalogItemOptionMtom"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public CatalogItemOptionMtom Result { get; set; }
    }
}
