using ServiceNow.Graph.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type DateTimeTimeZone.
    /// </summary>
    [JsonConverter(typeof(DerivedTypeConverter))]
    public partial class TestDateTimeTimeZone
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestDateTimeTimeZone"/> class.
        /// </summary>
        public TestDateTimeTimeZone()
        {
            this.ODataType = "serviceNow.graph.dateTimeTimeZone";
        }

        /// <summary>
        /// Gets or sets dateTime.
        /// A single point of time in a combined date and time representation ({date}T{time}; for example, 2017-08-29T04:00:00.0000000).
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "dateTime", Required = Required.Default)]
        public string DateTime
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets timeZone.
        /// Represents a time zone, for example, 'Pacific Standard Time'. See below for more possible values.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "timeZone", Required = Required.Default)]
        public string TimeZone
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
