using System.Collections.Generic;
using System.Text.Json.Serialization;
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
        [JsonPropertyName("enumType")]
        public EnumType? EnumType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets link.
        /// </summary>
        [JsonPropertyName("link")]
        public string WebUrl
        {
            get; set;
        }
    }
}
