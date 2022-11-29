using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// A property bag class for testing derived type deserialization.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class DerivedTypeClass : AbstractEntityType
    {
        /// <summary>
        /// Gets or sets enumType.
        /// </summary>
        [JsonProperty("enumType")]
        public EnumType? EnumType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name", Required = Required.Default)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets link.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "link", Required = Required.Default)]
        public string WebUrl
        {
            get; set;
        }
    }
}
