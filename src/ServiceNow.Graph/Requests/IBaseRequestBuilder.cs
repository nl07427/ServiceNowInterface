namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The base request builder interface.
    /// </summary>
    public interface IBaseRequestBuilder
    {
        /// <summary>
        /// Gets the <see cref="IBaseClient"/> for handling requests.
        /// </summary>
        IBaseClient Client { get; }

        /// <summary>
        /// Gets the URL for the built request, without query string.
        /// </summary>
        string RequestUrl { get; }

        /// <summary>
        /// Gets a URL that is the request builder's request URL with the segment appended.
        /// </summary>
        /// <param name="urlSegment">The segment to append to the request URL.</param>
        /// <returns>A URL that is the request builder's request URL with the segment appended.</returns>
        string AppendSegmentToRequestUrl(string urlSegment);
    }
}
