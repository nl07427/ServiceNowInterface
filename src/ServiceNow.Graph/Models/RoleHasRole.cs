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
        /// Parent role, reference to sys_user_role
        /// </summary>
        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// Child role, reference to sys_user_role
        /// </summary>
        [JsonProperty(PropertyName = "contains", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Child { get; set; }
    }
}
