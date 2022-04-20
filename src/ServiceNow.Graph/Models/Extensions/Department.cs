using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    public partial class Department
    {
        /// <summary>
        /// Type lab, X40
        /// </summary>
        [JsonProperty(PropertyName = "x_keral_lab_type_lab", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string XKeralLabTypeLab { get; set; }

        /// <summary>
        /// Active, bool
        /// </summary>
        [JsonProperty(PropertyName = "u_active", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Active { get; set; }
    }
}
