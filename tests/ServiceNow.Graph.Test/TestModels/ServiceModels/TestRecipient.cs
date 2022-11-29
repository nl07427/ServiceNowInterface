using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    public class TestRecipient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestRecipient"/> class.
        /// </summary>
        public TestRecipient()
        {
            this.ODataType = "serviceNow.graph.recipient";
        }

        /// <summary>
        /// Gets or sets emailAddress.
        /// The recipient's email address.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "emailAddress", Required = Required.Default)]
        public TestEmailAddress EmailAddress
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

        /// <summary>
        /// Gets or sets @odata.type.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "@odata.type", Required = Required.Default)]
        public string ODataType
        {
            get; set;
        }
    }
}
