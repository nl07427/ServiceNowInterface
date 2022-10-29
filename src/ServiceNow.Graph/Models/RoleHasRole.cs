using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_user_role_contains table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RoleHasRole : ApplicationFile
    {
        /// <summary>
        /// RoleHasRole constructor
        /// </summary>
        public RoleHasRole()
        {
            ObjectType = "sys_user_role_contains";
        }

        /// <summary>
        /// Role, reference to sys_user_role
        /// </summary>
        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Role { get; set; }

        /// <summary>
        /// Contained role, reference to sys_user_role
        /// </summary>
        [JsonProperty(PropertyName = "contains", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Contains { get; set; }
    }
}
