using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type Entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class Entity
    {
        ///<summary>
        /// The internal Entity constructor
        ///</summary>
        protected internal Entity()
        {
            // Don't allow initialization of abstract entity types
        }

        /// <summary>
        /// Gets or sets sys_class_name (table name).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_class_name", Required = Required.Default)]
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the user id that created the record.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_created_by", Required = Required.Default)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets the create timestamp of the record.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_created_on", Required = Required.Default)]
        public DateTime WhenCreated {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets id.
        /// Read-only.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_id", Required = Required.Default)]
        public string Id { get; set; }

        /// <summary>
        /// Count of updates to this record
        /// </summary>
        [JsonProperty(PropertyName = "sys_mod_count", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? SysModCount { get; set; }

        /// <summary>
        /// Gets or sets the user id that last updated the record.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_updated_by", Required = Required.Default)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// Gets the update timestamp of the record.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_updated_on", Required = Required.Default)]
        public DateTime WhenUpdated
        {
            get;
            set;
        }
    }
}
