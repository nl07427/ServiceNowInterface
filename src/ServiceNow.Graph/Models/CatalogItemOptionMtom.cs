using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow table sc_item_option mtom, Variable ownership
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogItemOptionMtom : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CatalogItemOptionMtom()
        {
            this.ObjectType = "sc_item_option_mtom";
        }

        /// <summary>
        /// Reference to the sc_req_item
        /// </summary>
        [JsonProperty(PropertyName = "request_item", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink RequestItem { get; set; }

        /// <summary>
        /// Reference to the catalog option, sc_item_option
        /// </summary>
        [JsonProperty(PropertyName = "sc_item_option", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ScItemOption { get; set; }
    }
}
