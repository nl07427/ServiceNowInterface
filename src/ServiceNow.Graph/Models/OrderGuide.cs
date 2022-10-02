using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sc_cat_item_guide, order guides
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]

    public class OrderGuide : CatalogItem
    {

        /// <summary>
        /// Constructor OrderGuide
        /// </summary>
        public OrderGuide()
        {
            ObjectType = "sc_cat_item_guide";
        }
        /// <summary>
        /// Cascade Variables,bool
        /// </summary>
        [JsonProperty(PropertyName = "cascade", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Cascade { get; set; }

        /// <summary>
        /// Include Toggle (Service Portal), bool
        /// </summary>
        [JsonProperty(PropertyName = "include_items", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? IncludeItems { get; set; }

        /// <summary>
        /// Order to cart, bool
        /// </summary>
        [JsonProperty(PropertyName = "order_to_cart", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? OrderToCart { get; set; }

        /// <summary>
        /// Script, X4000
        /// </summary>
        [JsonProperty(PropertyName = "script", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Script { get; set; }

        /// <summary>
        /// Two step, bool
        /// </summary>
        [JsonProperty(PropertyName = "two_step", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? TwoStep { get; set; }

        /// <summary>
        /// Script, X4000
        /// </summary>
        [JsonProperty(PropertyName = "validator", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Validator { get; set; }
    }
}
