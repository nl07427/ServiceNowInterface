using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    /// <summary>
    /// Extensions of the class Location which references the cmn_location table in ServiceNow
    /// </summary>
    public partial class Location
    {
        /// <summary>
        /// Reference to sys_user_group table, the IT Managers of the location
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_i_t_managers", Required = Required.Default)]
        public ReferenceLink ItManagers { get; set; }

        /// <summary>
        /// Reference to sys_user_group table, RH approvers
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_rh_approvers", Required = Required.Default)]
        public ReferenceLink RhApprovers { get; set; }

        /// <summary>
        /// Reference to sys_user_group table, the IT support group of the location
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_support_i_t", Required = Required.Default)]
        public ReferenceLink ItSupport { get; set; }
    }
}
