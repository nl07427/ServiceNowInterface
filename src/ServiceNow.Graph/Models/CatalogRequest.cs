using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// Representation of ServiceNow sc_request table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class CatalogRequest : Task
    {
        private DateTimeOffset? _requestedForDate;

        /// <summary>
        /// Default constructor for CatalogRequest
        /// </summary>
        public CatalogRequest()
        {
            ObjectType = "sc_request";
        }

        /// <summary>
        /// Resolve time, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "calendar_stc", Required = Required.Default)]
        public Int32? CalendarStc { get; set; }

        /// <summary>
        /// Delivery address, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "delivery_address", Required = Required.Default)]
        public string DeliveryAddress { get; set; }

        /// <summary>
        /// Reference to interaction table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_interaction", Required = Required.Default)]
        public ReferenceLink ParentInteraction { get; set; }

        /// <summary>
        /// Price, ServiceNow currency, X20 (see: https://docs.servicenow.com/bundle/orlando-platform-administration/page/administer/currency/concept/configure-and-use-default-currency-fields.html)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "price", Required = Required.Default)]
        public string Price { get; set; }

        /// <summary>
        /// Request for date
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "requested_date", Required = Required.Default)]
        public DateTimeOffset? RequestedForDate
        {
            get => _requestedForDate;
            set
            {
                if (value.HasValue)
                {
                    _requestedForDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Request for, reference to User (sys_user) table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "requested_for", Required = Required.Default)]
        public ReferenceLink RequestedFor { get; set; }

        /// <summary>
        /// Request state
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_state", Required = Required.Default)]
        public string RequestState { get; set; }

        /// <summary>
        /// Special instructions, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "special_instructions", Required = Required.Default)]
        public string SpecialInstructions { get; set; }

        /// <summary>
        /// Workflow stage, ServiceNow Workflow type field
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "stage", Required = Required.Default)]
        public string Stage { get; set; }
    }
}
