using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type UserEventsCollectionResponse.
    /// </summary>

    public class TestEventDeltaCollectionResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="ITestEventDeltaCollectionPage"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "value", Required = Required.Default)]
        public ITestEventDeltaCollectionPage Value
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the referenceLink value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "referenceLink", Required = Required.Default)]
        [JsonConverter(typeof(ReferenceLinkConverter))]
        public ReferenceLink ReferenceLink
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
