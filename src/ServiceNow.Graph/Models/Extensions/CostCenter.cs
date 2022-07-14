using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// Extensions of the class CostCenter which references the cmn_cost_center table in ServiceNow
    /// </summary>
    public partial class CostCenter
    {
        /// <summary>
        /// Cost code
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_cost_code", Required = Required.Default)]
        public string CostCode { get; set; }

        /// <summary>
        /// Ventilation level
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_vent_level", Required = Required.Default)]
        public string VentilationLevel
        {
            get; set;
        }
    }
}
