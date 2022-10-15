using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_group_has_role table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GroupHasRole : Entity
    {
        /// <summary>
        /// GroupHasRole constructor
        /// </summary>
        public GroupHasRole()
        {
            ObjectType = "sys_group_has_role";
        }

        /// <summary>
        /// Granted by, reference to sys_user_group
        /// </summary>
        [JsonProperty(PropertyName = "granted_by", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink GrantedBy { get; set; }

        /// <summary>
        /// Group, reference to sys_user_group
        /// </summary>
        [JsonProperty(PropertyName = "group", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Group { get; set; }

        /// <summary>
        /// Inherits, boolean
        /// </summary>
        [JsonProperty(PropertyName = "inherits", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Inherits { get; set; }

        /// <summary>
        /// Role, reference to sys_user_role table
        /// </summary>
        [JsonProperty(PropertyName = "role", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Role { get; set; }
    }
}
