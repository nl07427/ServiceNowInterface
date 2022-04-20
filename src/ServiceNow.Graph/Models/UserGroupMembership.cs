using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// Group membership, sys_user_grmember table in ServiceNow
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class UserGroupMembership : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public UserGroupMembership()
        {
            ObjectType = "sys_user_groupMember";
        }

        /// <summary>
        /// User
        /// </summary>
        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink User { get; set; }

        /// <summary>
        /// Group
        /// </summary>
        [JsonProperty(PropertyName = "group", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Group { get; set; }
    }
}
