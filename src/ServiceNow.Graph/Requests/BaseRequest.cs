using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Requests.Middleware;
using ServiceNow.Graph.Requests.Middleware.Options;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The base request class.
    /// </summary>
    public class BaseRequest : IBaseRequest
    {
        /// <summary>
        /// Constructs a new <see cref="BaseRequest"/>.
        /// </summary>
        /// <param name="requestUrl">The URL for the request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        /// <param name="options">The header and query options for the request.</param>
        public BaseRequest(
            string requestUrl,
            IBaseClient client,
            IEnumerable<Option> options = null)
        {
            Method = "GET";
            Client = client;
            ResponseHandler = new ResponseHandler(client.HttpProvider.Serializer);
            Headers = new List<HeaderOption>();
            QueryOptions = new List<QueryOption>();
            MiddlewareOptions = new Dictionary<string, IMiddlewareOption>();
            RequestUrl = InitializeUrl(requestUrl);

            if (options != null)
            {
                var enumerable = options as Option[] ?? options.ToArray();
                var headerOptions = enumerable.OfType<HeaderOption>();

                ((List<HeaderOption>) Headers).AddRange(headerOptions);

                var queryOptions = enumerable.OfType<QueryOption>();
                ((List<QueryOption>) QueryOptions).AddRange(queryOptions);
            }

            // Adds the default authentication provider for this request. 
            // This can be changed can be changed by the user by calling WithPerRequestAuthProvider extension method.
            this.WithDefaultAuthProvider();
        }

        /// <summary>
        /// Gets or sets the response handler for the request.
        /// </summary>
        public IResponseHandler ResponseHandler { get; set; }

        /// <summary>
        /// Gets or sets the content type for the request.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets the <see cref="HeaderOption"/> collection for the request.
        /// </summary>
        public IList<HeaderOption> Headers { get; }

        /// <summary>
        /// Gets the <see cref="IBaseClient"/> for handling requests.
        /// </summary>
        public IBaseClient Client { get; }

        /// <summary>
        /// Gets or sets the HTTP method string for the request.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Gets the <see cref="QueryOption"/> collection for the request.
        /// </summary>
        public IList<QueryOption> QueryOptions { get; set; }

        /// <summary>
        /// Gets the URL for the request, without query string.
        /// </summary>
        public string RequestUrl { get; internal set; }

        /// <summary>
        /// Gets or sets middleware options for the request.
        /// </summary>
        public IDictionary<string, IMiddlewareOption> MiddlewareOptions { get; }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The task to await.</returns>
        public async Task SendAsync(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            using (await SendRequestAsync(serializableObject, cancellationToken, completionOption)
                .ConfigureAwait(false))
            {
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <typeparam name="T">The expected response object type for deserialization.</typeparam>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The deserialized response object.</returns>
        public async Task<T> SendAsync<T>(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            using (var response = await SendRequestAsync(serializableObject, cancellationToken, completionOption)
                .ConfigureAwait(false))
            {
                return await ResponseHandler.HandleResponse<T>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sends the multipart request.
        /// </summary>
        /// <typeparam name="T">The expected response object type for deserialization.</typeparam>
        /// <param name="multipartContent">The multipart object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The deserialized response object.</returns>
        public async Task<T> SendMultiPartAsync<T>(
            MultipartContent multipartContent,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            using (var response = await SendMultiPartRequestAsync(multipartContent, cancellationToken, completionOption)
                .ConfigureAwait(false))
            {
                return await ResponseHandler.HandleResponse<T>(response).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The stream.</returns>
        public async Task<Stream> SendStreamRequestAsync(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            var response = await SendRequestAsync(serializableObject, cancellationToken, completionOption)
                .ConfigureAwait(false);
            return await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Sends the multipart request.
        /// </summary>
        /// <param name="multipartContent">The multipart object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> object.</returns>
        public async Task<HttpResponseMessage> SendMultiPartRequestAsync(
            MultipartContent multipartContent,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            if (string.IsNullOrEmpty(RequestUrl))
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            DetailedMessage = ErrorConstants.Messages.RequestUrlMissing,
                            Message = ErrorConstants.Codes.InvalidRequest
                        }
                    });
            }

            if (multipartContent == null)
                throw new Exception("The Multipart content is null. Set the multipart content.");
            using (var request = GetHttpRequestMessage(cancellationToken))
            {
                // Only call `AuthenticateRequestAsync` when a custom IHttpProvider is used or our HttpProvider is used without an auth handler.
                if (ShouldAuthenticateRequest())
                    await AuthenticateRequestAsync(request).ConfigureAwait(false);

                request.Content = multipartContent;

                return await Client.HttpProvider.SendAsync(request, completionOption, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="serializableObject">The serializable object to send.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <param name="completionOption">The <see cref="HttpCompletionOption"/> to pass to the <see cref="IHttpProvider"/> on send.</param>
        /// <returns>The <see cref="HttpResponseMessage"/> object.</returns>
        public async Task<HttpResponseMessage> SendRequestAsync(
            object serializableObject,
            CancellationToken cancellationToken,
            HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead)
        {
            if (string.IsNullOrEmpty(RequestUrl))
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            DetailedMessage = ErrorConstants.Messages.RequestUrlMissing,
                            Message = ErrorConstants.Codes.InvalidRequest
                        }
                    });
            }

            using (var request = GetHttpRequestMessage(cancellationToken))
            {
                // Only call `AuthenticateRequestAsync` when a custom IHttpProvider is used or our HttpProvider is used without an auth handler.
                if (ShouldAuthenticateRequest())
                    await AuthenticateRequestAsync(request).ConfigureAwait(false);

                switch (serializableObject)
                {
                    case null:
                        return await Client.HttpProvider.SendAsync(request, completionOption, cancellationToken)
                            .ConfigureAwait(false);
                    case Stream inputStream:
                        request.Content = new StreamContent(inputStream);
                        break;
                    default:
                        request.Content =
                            new StringContent(Client.HttpProvider.Serializer.SerializeObject(serializableObject));
                        break;
                }

                if (!string.IsNullOrEmpty(ContentType))
                {
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(ContentType);
                }

                return await Client.HttpProvider.SendAsync(request, completionOption, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Gets the <see cref="HttpRequestMessage"/> representation of the request.
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>The <see cref="HttpRequestMessage"/> representation of the request.</returns>
        public HttpRequestMessage GetHttpRequestMessage(CancellationToken cancellationToken)
        {
            var queryString = BuildQueryString();
            var request = new HttpRequestMessage(new HttpMethod(Method), string.Concat(RequestUrl, queryString));
            AddHeadersToRequest(request);
            AddRequestContextToRequest(request, cancellationToken);
            return request;
        }

        /// <summary>
        /// Gets the <see cref="HttpRequestMessage"/> representation of the request.
        /// </summary>
        /// <returns>The <see cref="HttpRequestMessage"/> representation of the request.</returns>
        public HttpRequestMessage GetHttpRequestMessage()
        {
            return GetHttpRequestMessage(CancellationToken.None);
        }

        /// <summary>
        /// Adds all of the headers from the header collection to the request.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> representation of the request.</param>
        private void AddHeadersToRequest(HttpRequestMessage request)
        {
            if (Headers == null) return;
            foreach (var header in Headers)
            {
                request.Headers.TryAddWithoutValidation(header.Name, header.Value);
            }
        }

        /// <summary>
        /// Adds a <see cref="ServiceNowRequestContext"/> to <see cref="HttpRequestMessage"/> property bag
        /// </summary>
        /// <param name="httpRequestMessage">A <see cref="HttpRequestMessage"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/></param>
        private void AddRequestContextToRequest(HttpRequestMessage httpRequestMessage,
            CancellationToken cancellationToken)
        {
            // Creates a request context object
            var requestContext = new ServiceNowRequestContext()
            {
                MiddlewareOptions = MiddlewareOptions,
                ClientRequestId = GetHeaderValue(httpRequestMessage, Constants.Headers.ClientRequestId) ??
                                  Guid.NewGuid().ToString(),
                CancellationToken = cancellationToken,
                FeatureUsage = httpRequestMessage.GetFeatureFlags()
            };

            httpRequestMessage.Properties.Add(typeof(ServiceNowRequestContext).ToString(), requestContext);
        }

        /// <summary>
        /// Gets a URL that is the request builder's request URL with the segment appended.
        /// </summary>
        /// <param name="urlSegment">The segment to append to the request URL.</param>
        /// <returns>A URL that is the request builder's request URL with the segment appended.</returns>
        public void AppendSegmentToRequestUrl(string urlSegment)
        {
            RequestUrl = $"{RequestUrl}/{urlSegment}";
        }

        /// <summary>
        /// Returns the next page url that the ServiceNow REST API returns in the Link HTTP header
        /// </summary>
        /// <param name="nextPageLink"></param>
        /// <returns></returns>
        public static string NextPageLinkString(JToken nextPageLink)
        {
            string nextPageLinkString = null;
            if (!string.IsNullOrEmpty(nextPageLink.First.ToString()))
            {
                foreach (var x in nextPageLink.First.ToString().Split(','))
                {
                    if (!x.Contains("rel=\"next\"")) continue;
                    nextPageLinkString = x;
                    break;
                }

                if (nextPageLinkString != null)
                {
                    foreach (var x in nextPageLinkString.Split(';'))
                    {
                        if (!x.StartsWith("<")) continue;
                        nextPageLinkString = x;
                        break;
                    }

                    nextPageLinkString = nextPageLinkString.TrimStart('<').TrimEnd('>');
                }
            }

            return nextPageLinkString;
        }

        /// <summary>
        /// Builds the query string for the request from the query option collection.
        /// </summary>
        /// <returns>The constructed query string.</returns>
        internal string BuildQueryString()
        {
            if (QueryOptions == null) return null;
            var stringBuilder = new StringBuilder();

            foreach (var queryOption in QueryOptions)
            {
                // Escape any special uri characters in the queryOption data 
                // We first decode/escape the string in case the user has already encoded it to prevent double encoding
                var unescapedData = Uri.UnescapeDataString(queryOption.Value);
                var escapedOptionValue = Uri.EscapeDataString(unescapedData);

                stringBuilder.AppendFormat(stringBuilder.Length == 0 ? "?{0}={1}" : "&{0}={1}", queryOption.Name,
                    escapedOptionValue);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Adds the authentication header to the request. This is a patch to support request authentication for custom HttpProviders.
        /// </summary>
        /// <param name="request">The <see cref="HttpRequestMessage"/> representation of the request.</param>
        /// <returns>The task to await.</returns>
        private async Task AuthenticateRequestAsync(HttpRequestMessage request)
        {
            if (Client.AuthenticationProvider == null)
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            DetailedMessage = ErrorConstants.Messages.AuthenticationProviderMissing,
                            Message = ErrorConstants.Codes.InvalidRequest
                        }
                    });
            }

            await Client.AuthenticationProvider.AuthenticateRequestAsync(request).ConfigureAwait(false);
        }

        /// <summary>
        /// Initializes the request URL for the request, breaking it into query options and base URL.
        /// </summary>
        /// <param name="requestUrl">The request URL.</param>
        /// <returns>The request URL minus query string.</returns>
        private string InitializeUrl(string requestUrl)
        {
            if (string.IsNullOrEmpty(requestUrl))
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            DetailedMessage = ErrorConstants.Messages.BaseUrlMissing,
                            Message = ErrorConstants.Codes.InvalidRequest
                        }
                    });
            }

            var uri = new Uri(requestUrl);

            if (string.IsNullOrEmpty(uri.Query)) return new UriBuilder(uri) {Query = string.Empty}.ToString();
            var queryString = uri.Query;
            if (queryString[0] == '?')
            {
                queryString = queryString.Substring(1);
            }

            var queryOptions = queryString.Split('&').Select(
                queryValue =>
                {
                    // We want to split on the first occurrence of = since there are scenarios where a query option can 
                    // have 'sub-query' options on navigation properties for $expand scenarios. This way we can properly
                    // split the query option name/value into the QueryOption object. Take this for example:
                    // $expand=extensions($filter=Id%20eq%20'SMB'%20)
                    // We want to get '$expand' as the name and 'extensions($filter=Id%20eq%20'SMB'%20)' as the value
                    // for QueryOption object.
                    // OData URL conventions 5.1.2 System Query Option $expand
                    // http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part2-url-conventions/odata-v4.0-errata03-os-part2-url-conventions-complete.html#_Toc453752359

                    var segments = queryValue.Split(new[] {'='}, 2);
                    return new QueryOption(
                        segments[0],
                        segments.Length > 1 ? segments[1] : string.Empty);
                });

            foreach (var queryOption in queryOptions)
            {
                QueryOptions.Add(queryOption);
            }

            return new UriBuilder(uri) {Query = string.Empty}.ToString();
        }

        /// <summary>
        /// Gets a specified header value from <see cref="HttpRequestMessage"/>
        /// </summary>
        /// <param name="requestMessage">A <see cref="HttpRequestMessage"/></param>
        /// <param name="headerName">The name, or key, of the header option.</param>
        /// <returns>Header value</returns>
        private string GetHeaderValue(HttpRequestMessage requestMessage, string headerName)
        {
            string headerValue = null;
            var requestHeader = Headers.FirstOrDefault((h) => h.Name.Equals(headerName));

            // Check request headers first
            if (requestHeader != null)
            {
                headerValue = requestHeader.Value;
            }
            // If not found, check http client default headers + request headers
            else if (requestMessage.Headers != null)
            {
                if (requestMessage.Headers.TryGetValues(headerName, out var values))
                {
                    headerValue = values.FirstOrDefault();
                }
            }

            return headerValue;
        }

        /// <summary>
        /// Determines whether or not <see cref="BaseRequest"/> should authenticate the request or let <see cref="AuthenticationHandler"/> authenticate the request.
        /// </summary>
        /// <returns>
        /// TRUE: If a CUSTOM <see cref="IHttpProvider"/> or DEFAULT <see cref="HttpProvider"/> is used WITHOUT an <see cref="AuthenticationHandler"/>.
        /// FALSE: If our DEFAULT <see cref="HttpProvider"/> or <see cref="SimpleHttpProvider"/> is used WITH an <see cref="AuthenticationHandler"/>.
        /// </returns>
        private bool ShouldAuthenticateRequest()
        {
            switch (Client.HttpProvider)
            {
                case HttpProvider provider when provider.HttpClient.ContainsFeatureFlag(FeatureFlag.AuthHandler):
                    return false; //no need to authenticate as we have an AuthHandler provided 

                case SimpleHttpProvider simpleHttpProvider
                    when simpleHttpProvider.HttpClient.ContainsFeatureFlag(FeatureFlag.AuthHandler):
                    return false; //no need to authenticate as we have an AuthHandler provided 

                default:
                    return true;
            }
        }
    }
}
