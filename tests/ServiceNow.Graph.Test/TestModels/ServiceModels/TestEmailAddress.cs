using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type TestEmailAddress.
    /// </summary>
    public partial class TestEmailAddress
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestEmailAddress"/> class.
        /// </summary>
        public TestEmailAddress()
        {
            this.ODataType = "microsoft.graph.emailAddress";
        }

        /// <summary>
        /// Gets or sets name.
        /// The display name of the person or entity.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name", Required = Required.Default)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets address.
        /// The email address of the person or entity.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "address", Required = Required.Default)]
        public string Address
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
