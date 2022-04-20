using Newtonsoft.Json;

namespace ServiceNow.Graph.Exceptions
{
    /// <summary>
    /// Error details, the message and details attribute as returned by the ServiceNow table API
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ErrorDetail
    {
        /// <summary>The error message.</summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "message", Required = Required.Default)]
        public string Message { get; set; }

        /// <summary>
        /// Indicates the detailed error message
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "detail", Required = Required.Default)]
        public string DetailedMessage { get; set; }
    }
}
