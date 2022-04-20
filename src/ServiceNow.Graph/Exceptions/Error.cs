using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Exceptions
{
    /// <summary>
    /// The error object as returned in the body of responses in the response code range of 400 and 500
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Error
    {
        /// <summary>
        /// The error details of the response.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "error",
            Required = Required.Default)]
        public ErrorDetail ErrorDetail { get; set; }

        /// <summary>
        /// The error status.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status", Required = Required.Default)]
        public string ErrorStatus { get; set; }

        /// <summary>
        /// Gets or set the client-request-id header returned in the response headers collection. 
        /// </summary>
        public string ClientRequestId { get; internal set; }

        /// <summary>
        /// The AdditionalData property bag.
        /// </summary>
        [JsonExtensionData(ReadData = true)]
        public IDictionary<string, object> AdditionalData { get; set; }

        /// <summary>
        /// JSON error string formatted for human consumption
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            if (ErrorDetail == null) return stringBuilder.ToString();
            if (!string.IsNullOrEmpty(ErrorDetail.Message))
            {
                stringBuilder.AppendFormat("Message: {0}", new[]
                {
                    (object) ErrorDetail.Message
                });
                stringBuilder.Append(Environment.NewLine);
            }

            if (string.IsNullOrEmpty(ErrorDetail.DetailedMessage)) return stringBuilder.ToString();
            stringBuilder.AppendFormat("Detailed error message: {0}", new[]
            {
                (object) ErrorDetail.DetailedMessage
            });
            stringBuilder.Append(Environment.NewLine);

            return stringBuilder.ToString();
        }
    }
}
