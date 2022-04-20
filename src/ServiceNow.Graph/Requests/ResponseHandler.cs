using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Provides method(s) to deserialize raw HTTP responses into strong types.
    /// </summary>
    public class ResponseHandler : IResponseHandler
    {
        private readonly ISerializer _serializer;

        /// <summary>
        /// Constructs a new <see cref="ResponseHandler"/>.
        /// </summary>
        /// <param name="serializer"></param>
        public ResponseHandler(ISerializer serializer)
        {
            this._serializer = serializer;
        }

        /// <summary>
        /// Process raw HTTP response into requested domain type.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="response">The HttpResponseMessage to handle</param>
        /// <returns></returns>
        public async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (response.Content == null) return default;
            var responseString = await GetResponseString(response).ConfigureAwait(false);
            return _serializer.DeserializeObject<T>(responseString);
        }

        /// <summary>
        /// Get the response content string
        /// </summary>
        /// <param name="hrm">The response object</param>
        /// <returns>The full response string to return</returns>
        private async Task<string> GetResponseString(HttpResponseMessage hrm)
        {
            var responseContent = "";

            var content = await hrm.Content.ReadAsStringAsync().ConfigureAwait(false);

            //Only add headers if we are going to return a response body
            if (content.Length == 0) return responseContent;
            var responseHeaders = hrm.Headers;
            var statusCode = hrm.StatusCode;

            var headerDictionary = responseHeaders.ToDictionary(x => x.Key, x => x.Value.ToArray());
            var responseHeaderString = _serializer.SerializeObject(headerDictionary);

            responseContent = content.Substring(0, content.Length - 1) + ", ";
            responseContent += "\"responseHeaders\": " + responseHeaderString + ", ";
            responseContent += "\"statusCode\": \"" + statusCode + "\"}";

            return responseContent;
        }
    }
}
