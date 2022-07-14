using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow request items table (sc_req_item)
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RequestItem : Task
    {
        private DateTimeOffset? _estimatedDelivery;

        /// <summary>
        /// Default constructor
        /// </summary>
        public RequestItem()
        {
            ObjectType = "sc_req_item";
        }

        /// <summary>
        /// Reference to service catalog
        /// </summary>
        [JsonProperty(PropertyName = "sc_catalog", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Catalog { get; set; }

        /// <summary>
        /// Price, ServiceNow currency field type, X20
        /// </summary>
        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Price { get; set; }

        /// <summary>
        /// Recurring price frequency, ServiceNow choice field type, X40
        /// </summary>
        [JsonProperty(PropertyName = "recurring_frequency", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RecurringFrequency { get; set; }

        /// <summary>
        /// Reference to the workflow context, X32
        /// </summary>
        [JsonProperty(PropertyName = "context", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Context { get; set; }

        /// <summary>
        ///  Back ordered
        /// </summary>
        [JsonProperty(PropertyName = "backordered", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Backordered { get; set; }

        /// <summary>
        /// Flow context
        /// </summary>
        [JsonProperty(PropertyName = "flow_context", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink FlowContext { get; set; }

        /// <summary>
        /// Reference to cmdb_ci table
        /// </summary>
        [JsonProperty(PropertyName = "configuration_item", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ConfigurationItem { get; set; }

        /// <summary>
        /// Reference to order guide table, sc_cat_item_guide
        /// </summary>
        [JsonProperty(PropertyName = "order_guide", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink OrderGuide { get; set; }

        /// <summary>
        /// Reference to catalog request table, sc_request
        /// </summary>
        [JsonProperty(PropertyName = "request", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Request { get; set; }

        /// <summary>
        /// Recurring price, ServiceNow Price field type, X20
        /// </summary>
        [JsonProperty(PropertyName = "recurring_price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RecurringPrice { get; set; }

        /// <summary>
        /// Billable, boolean
        /// </summary>
        [JsonProperty(PropertyName = "billable", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Billable { get; set; }

        /// <summary>
        /// Reference to the catalog item, sc_cat_item
        /// </summary>
        [JsonProperty(PropertyName ="cat_item", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CatalogItem { get; set; }

        /// <summary>
        /// Workflow stage, X80, default value is 'Waiting for approval'
        /// </summary>
        [JsonProperty(PropertyName = "stage", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Stage { get; set; }

        /// <summary>
        /// Quantity, int but using string
        /// </summary>
        [JsonProperty(PropertyName = "quantity", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Quantity { get; set; }

        /// <summary>
        /// Estimated delivery timestamp
        /// </summary>
        [JsonProperty(PropertyName = "estimated_delivery", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? EstimatedDelivery
        {
            get => _estimatedDelivery;
            set
            {
                if (value.HasValue)
                {
                    _estimatedDelivery = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Request for, reference to User (sys_user) table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "requested_for", Required = Required.Default)]
        public ReferenceLink RequestedFor
        {
            get; set;
        }
    }
}
