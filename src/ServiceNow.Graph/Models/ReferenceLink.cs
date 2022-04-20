using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow reference link (see sysparm_exclude_reference_link query parameter)
    /// We expect when deserializing JSON data that the sysparm_exclude_reference_link query parameter is equal to
    /// the default value (false)
    /// </summary>

    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(ReferenceLinkConverter))]
    public class ReferenceLink
    {
        /// <summary>
        /// Link, absolute link to retrieve the referenced value
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "link", Required = Required.Default)]
        public string Link { get; set; }

        /// <summary>
        /// Value, sys_id (key) of the referenced value
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "value", Required = Required.Default)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Value;
        }
    }
}
