using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    /// <summary>
    /// Extensions of the ServiceNow sc_cat_item.
    /// </summary>
    public partial class CatalogItem
    {
        /// <summary>
        /// Requires HR Approval, bool
        /// </summary>
        [JsonProperty(PropertyName = "u_requires_hr_approval", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? URequiresHrApproval { get; set; }

        /// <summary>
        /// Number, X40
        /// </summary>
        [JsonProperty(PropertyName = "u_number", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string UNumber { get; set; }

        /// <summary>
        /// Requires Special Approval Group, sys_user_group reference
        /// </summary>
        [JsonProperty(PropertyName = "u_requires_special_approval_group", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink URequiresSpecialApprovalGroup { get; set; }

        /// <summary>
        /// New Icon, X100
        /// </summary>
        [JsonProperty(PropertyName = "u_icon_1", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string UIcon1 { get; set; }

        /// <summary>
        /// Requires I.T Manager Approval, bool
        /// </summary>
        [JsonProperty(PropertyName = "u_requires_i_t_manager_approval", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? URequiresItManagerApproval { get; set; }

        /// <summary>
        /// Delivery choice, X40
        /// </summary>
        [JsonProperty(PropertyName = "u_delivery_choice", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string UDeliveryChoice { get; set; }

        /// <summary>
        /// Requires Manager Approval, bool
        /// </summary>
        [JsonProperty(PropertyName = "u_requires_manager_approval", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? URequiresManagerApproval { get; set; }

        /// <summary>
        /// New Reference, cmdb_ci_appl_dot_net (cmdb_ci_appl_dot_net) reference
        /// </summary>
        [JsonProperty(PropertyName = "u_reference_1", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink UReference1 { get; set; }

        /// <summary>
        /// Requires Special Approval, bool
        /// </summary>
        [JsonProperty(PropertyName = "u_requires_special_approval", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? URequiresSpecialApproval { get; set; }
    }
}
