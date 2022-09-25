using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_metadata entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class ApplicationFile : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        protected internal ApplicationFile()
        {
            ObjectType = "sys_metadata";
        }

        /// <summary>
        /// Display name, X255
        /// </summary>
        [JsonProperty(PropertyName = "sys_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SysName { get; set; }

        /// <summary>
        /// Reference to sys_package
        /// </summary>
        [JsonProperty(PropertyName = "sys_package", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SysPackage { get; set; }

        /// <summary>
        /// Protection policy, X40
        /// </summary>
        [JsonProperty(PropertyName = "sys_policy", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SysPolicy { get; set; }

        /// <summary>
        /// Reference to Application (sys_scope)
        /// </summary>
        [JsonProperty(PropertyName = "sys_scope", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SysScope { get; set; }

        /// <summary>
        /// Update name, X250
        /// </summary>
        [JsonProperty(PropertyName = "sys_update_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SysUpdateName { get; set; }
    }
}
