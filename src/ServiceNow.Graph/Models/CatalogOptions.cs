using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// Catalog options (variable linked to a cart item)
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogOptions : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CatalogOptions()
        {
            this.ObjectType = "sc_item_option";
        }

        /// <summary>
        /// Reference to the service catalog item
        /// </summary>
        [JsonProperty(PropertyName ="sc_cat_item_option", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ItemOption { get; set; }

        /// <summary>
        /// Reference to the item/request variable
        /// </summary>
        [JsonProperty(PropertyName = "item_option_new", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Variable { get; set; }

        /// <summary>
        /// Reference to a cart item
        /// </summary>
        [JsonProperty(PropertyName = "cart_item", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CartItem { get; set; }

        /// <summary>
        /// Sort order
        /// </summary>
        [JsonProperty(PropertyName = "order", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public long? Order { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        [JsonProperty(PropertyName = "value", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Value { get; set; }

    }
}
