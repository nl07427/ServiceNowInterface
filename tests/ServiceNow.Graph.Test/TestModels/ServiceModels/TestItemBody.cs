using ServiceNow.Graph.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type ItemBody.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    public partial class TestItemBody
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestItemBody"/> class.
        /// </summary>
        public TestItemBody()
        {
            this.ODataType = "serviceNow.graph.itemBody";
        }

        /// <summary>
        /// Gets or sets contentType.
        /// The type of the content. Possible values are text and html.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "contentType", Required = Required.Default)]
        public EnumTypeWithFlags? ContentType
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets content.
        /// The content of the item.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "content", Required = Required.Default)]
        public string Content
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
