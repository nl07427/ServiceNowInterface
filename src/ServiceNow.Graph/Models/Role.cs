using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_user_role table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Role : ApplicationFile
    {
        /// <summary>
        /// Role constructor
        /// </summary>
        public Role()
        {
            ObjectType = "sys_user_role";
        }

        /// <summary>
        /// Assignable by, reference to sys_user_role
        /// </summary>
        [JsonProperty(PropertyName = "assignable_by", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink AssignableBy { get; set; }

        /// <summary>
        /// Can delegate, boolean
        /// </summary>
        [JsonProperty(PropertyName = "can_delegate", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? CanDelegate { get; set; }

        /// <summary>
        /// Description, X1000
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Elevated privilege, boolean
        /// </summary>
        [JsonProperty(PropertyName = "elevated_privilege", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? ElevatedPrivilege { get; set; }

        /// <summary>
        /// Grantable, boolean
        /// </summary>
        [JsonProperty(PropertyName = "grantable", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Grantable { get; set; }

        /// <summary>
        /// Includes roles, X40
        /// </summary>
        [JsonProperty(PropertyName = "includes_roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string IncludesRoles { get; set; }

        /// <summary>
        /// Name, X100
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Requires Subscription, X40
        /// </summary>
        [JsonProperty(PropertyName = "requires_subscription", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RequiresSubscription { get; set; }

        /// <summary>
        /// Application Administrator, boolean
        /// </summary>
        [JsonProperty(PropertyName = "scoped_admin", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? ApplicationAdministrator { get; set; }

        /// <summary>
        /// Suffix, X100
        /// </summary>
        [JsonProperty(PropertyName = "suffix", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Suffix { get; set; }
    }
}
