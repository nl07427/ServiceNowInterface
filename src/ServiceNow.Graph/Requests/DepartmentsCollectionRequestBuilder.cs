using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// DepartmentsCollectionRequestBuilder
    /// </summary>
    public class DepartmentsCollectionRequestBuilder :BaseRequestBuilder, IDepartmentsCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public DepartmentsCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public IDepartmentsCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public IDepartmentsCollectionRequest Request(IEnumerable<Option> options)
        {
            return new DepartmentsCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public IDepartmentRequestBuilder this[string id] => new DepartmentRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
