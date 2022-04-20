using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_user_has_role table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class UserHasRole : Entity
    {
        /// <summary>
        /// UserHasRole constructor
        /// </summary>
        public UserHasRole()
        {
            ObjectType = "sys_user_has_role";
        }

        /// <summary>
        /// Role, reference to sys_user_role table
        /// </summary>
        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Role { get; set; }

        /// <summary>
        /// Inheritance Map, UI Action List type, X255
        /// </summary>
        [JsonProperty(PropertyName = "inh_map", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string InheritanceMap { get; set; }

        /// <summary>
        /// Included in role, reference to sys_user_has_role table
        /// </summary>
        [JsonProperty(PropertyName = "included_in_role", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink IncludedInRole { get; set; }

        /// <summary>
        /// Included in role instance, reference to sys_user_role_contains table
        /// </summary>
        [JsonProperty(PropertyName = "included_in_role_instance", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink IncludedInRoleInstance { get; set; }

        /// <summary>
        /// Inheritance Count, integer
        /// </summary>
        [JsonProperty(PropertyName = "inh_count", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? InheritanceCount { get; set; }

        /// <summary>
        /// Granted by group, reference to sys_user_group table
        /// </summary>
        [JsonProperty(PropertyName = "granted_by", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink GrantedBy { get; set ; }

        /// <summary>
        /// Inherited, boolean
        /// </summary>
        [JsonProperty(PropertyName = "inherited", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Inherited { get; set; }

        /// <summary>
        /// State, X40
        /// </summary>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string State { get; set; }

        /// <summary>
        /// User, reference to sys_user table
        /// </summary>
        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink User { get; set; }
    }
}
