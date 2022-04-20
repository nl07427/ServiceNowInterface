using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Exceptions
{
    /// <summary>
    /// The error response object from the service on an unsuccessful call.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ErrorResponse
    {
        /// <summary>
        /// The <see cref="Error"/> returned by the service.
        /// </summary>
        [JsonProperty(PropertyName = "error")]
        public Error Error { get; set; }

        /// <summary>
        /// The error state as returned by ServiceNow, the value is 'failure' for 400 and 500 HTTP response codes
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status",
            Required = Required.Default)]
        public string Status { get; set; }

        /// <summary>
        /// Additional data returned in the call.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }
    }
}
