using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// LiveProfilesCollectionRequestBuilder
    /// </summary>
    public class LiveProfilesCollectionRequestBuilder : BaseRequestBuilder, ILiveProfilesCollectionRequestBuilder
    {
        /// <summary>
        /// LiveProfilesCollectionRequestBuilder constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public LiveProfilesCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds a profiles collection request
        /// </summary>
        /// <returns>ILiveProfilesCollectionRequest implementation</returns>
        public ILiveProfilesCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds a profiles (live_profile) collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ILiveProfilesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new LiveProfilesCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a ILiveProfileRequestBuilder implementation
        /// </summary>
        /// <param name="id"></param>
        public ILiveProfileRequestBuilder this[string id] => new LiveProfileRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
