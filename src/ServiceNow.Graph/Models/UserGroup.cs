using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_user_group table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class UserGroup : Entity
    {
        /// <summary>
        /// Default constructor for the sys_user_group table. The entity
        /// does not return an object type attribute
        /// </summary>
        public UserGroup()
        {
            ObjectType = "sys_user_group";
        }

        /// <summary>
        /// Parent group
        /// </summary>
        [JsonProperty(PropertyName = "parent", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// Manager / Owner of group
        /// </summary>
        [JsonProperty(PropertyName = "manager", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ReferenceLink Manager { get; set; }

        /// <summary>
        /// Roles
        /// </summary>
        [JsonProperty(PropertyName = "roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Roles { get; set; }

        /// <summary>
        /// Group active, boolean
        /// </summary>
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Active { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Source, X255
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Source { get; set; }

        /// <summary>
        /// Group type
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Type { get; set; }

        /// <summary>
        /// Cost center
        /// </summary>
        [JsonProperty(PropertyName = "cost_center", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CostCenter { get; set; }

        /// <summary>
        /// Default assigned user
        /// </summary>
        [JsonProperty(PropertyName = "default_assignee", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DefaultAssignee { get; set; }

        /// <summary>
        /// Hourly rate, ServiceNow currency type
        /// </summary>
        [JsonProperty(PropertyName = "hourly_rate", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string HourlyRate { get; set; }

        /// <summary>
        /// Group name, X80
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Exclude manager, boolean
        /// </summary>
        [JsonProperty(PropertyName = "exclude_manager", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? ExcludeManager { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Email { get; set; }

        /// <summary>
        /// Include group members, boolean
        /// </summary>
        [JsonProperty(PropertyName = "include_members", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? IncludeMembers { get; set; }
    }
}
