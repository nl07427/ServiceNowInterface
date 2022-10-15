using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// Service Catalog Task entity, equal to table sc_task in ServiceNow
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogTask :Task
    {
        /// <summary>
        /// Task constructor
        /// </summary>
        public CatalogTask()
        {
            ObjectType = "sc_task";
        }

        /// <summary>
        /// Resolve time, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore,PropertyName = "calendar_stc", Required = Required.Default)]
        public int? CalendarStc { get; }

        /// <summary>
        /// Reference to request table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore,PropertyName = "request", Required = Required.Default)]
        public ReferenceLink Request { get; set; }

        /// <summary>
        /// Reference to sc_req_item (catalog request item) table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_item", Required = Required.Default)]
        public ReferenceLink RequestItem { get; set; }

        /// <summary>
        /// Catalog, reference to table Catalog
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sc_catalog", Required = Required.Default)]
        public string ScCatalog { get; set; }
    }
}
