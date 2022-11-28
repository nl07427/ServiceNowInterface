using System.Collections.Generic;
using System.Text.Json.Serialization;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// A property bag class with no default constructor for unit testing purposes.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    public abstract class AbstractClass
    {
        protected AbstractClass()
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
