using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type TestEvent.
    /// </summary>

    public partial class TestEvent
    {

        ///<summary>
        /// The Event constructor
        ///</summary>
        public TestEvent()
        {
            this.ODataType = "serviceNow.graph.event";
        }

        /// <summary>
        /// Gets or sets id.
        /// Read-only.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id", Required = Required.Default)]
        public string Id
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

        /// <summary>
        /// Gets or sets additional data.
        /// </summary>
        [JsonExtensionData]
        public IDictionary<string, object> AdditionalData
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets subject.
        /// The text of the event's subject line.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject", Required = Required.Default)]
        public string Subject
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets body.
        /// The body of the message associated with the event. It can be in HTML or text format.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "body", Required = Required.Default)]
        public TestItemBody Body
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets end.
        /// The date, time, and time zone that the event ends. By default, the end time is in UTC.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "end", Required = Required.Default)]
        public TestDateTimeTimeZone End
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets start.
        /// The date, time, and time zone that the event starts. By default, the start time is in UTC.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "start", Required = Required.Default)]
        public TestDateTimeTimeZone Start
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets attendees.
        /// The collection of attendees for the event.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "attendees", Required = Required.Default)]
        public IEnumerable<TestAttendee> Attendees
        {
            get; set;
        }

    }
}
