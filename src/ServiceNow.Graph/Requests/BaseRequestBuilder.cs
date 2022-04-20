namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The base request builder class.
    /// </summary>
    public class BaseRequestBuilder
    {
        /// <summary>
        /// Constructs a new <see cref="BaseRequestBuilder"/>.
        /// </summary>
        /// <param name="requestUrl">The URL for the built request.</param>
        /// <param name="client">The <see cref="IBaseClient"/> for handling requests.</param>
        public BaseRequestBuilder(string requestUrl, IBaseClient client)
        {
            this.Client = client;
            this.RequestUrl = requestUrl;
        }

        /// <summary>
        /// Gets the <see cref="IBaseClient"/> for handling requests.
        /// </summary>
        public IBaseClient Client { get; }

        /// <summary>
        /// Gets the URL for the built request, without query string.
        /// </summary>
        public string RequestUrl { get; internal set; }

        /// <summary>
        /// Gets a URL that is the request builder's request URL with the segment appended.
        /// </summary>
        /// <param name="urlSegment">The segment to append to the request URL.</param>
        /// <returns>A URL that is the request builder's request URL with the segment appended.</returns>
        public string AppendSegmentToRequestUrl(string urlSegment)
        {
            return $"{RequestUrl}/{urlSegment}";
        }
    }
}
