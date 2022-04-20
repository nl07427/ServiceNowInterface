using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CompaniesCollectionRequestBuilder
    /// </summary>
    public class CompaniesCollectionRequestBuilder :BaseRequestBuilder, ICompaniesCollectionRequestBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CompaniesCollectionRequestBuilder(string requestUrl, IBaseClient client) : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <returns>Entity collection request implementation</returns>
        public ICompaniesCollectionRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the entity collection request
        /// </summary>
        /// <param name="options">Query and header options</param>
        public ICompaniesCollectionRequest Request(IEnumerable<Option> options)
        {
            return new CompaniesCollectionRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Returns a request builder implementation for the entity
        /// </summary>
        /// <param name="id"></param>
        public ICompanyRequestBuilder this[string id] => new CompanyRequestBuilder(AppendSegmentToRequestUrl(id), Client);
    }
}
