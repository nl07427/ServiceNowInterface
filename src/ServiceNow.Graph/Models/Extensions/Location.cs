using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    /// <summary>
    /// Extensions of the class Location which references the cmn_location table in ServiceNow
    /// </summary>
    public partial class Location
    {
        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_type", Required = Required.Default)]
        public string LocationType { get; set; }
    }
}
