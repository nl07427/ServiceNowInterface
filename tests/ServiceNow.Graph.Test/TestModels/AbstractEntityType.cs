using System.Collections.Generic;
using System.Text.Json.Serialization;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// A class to test abstract entity serialization and deserialization.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class AbstractEntityType
    {
        public AbstractEntityType()
        {

        }

        /// <summary>
        /// Gets or sets id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData
        {
            get; set;
        }
    }
}
