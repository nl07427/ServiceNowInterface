using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// CompanyRequestBuilder
    /// </summary>
    public class CompanyRequestBuilder : EntityRequestBuilder, ICompanyRequestBuilder
    {
        /// <summary>
        /// CompanyRequestBuilder
        /// </summary>
        /// <param name="requestUrl"></param>
        /// <param name="client"></param>
        public CompanyRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new ICompanyRequest Request(IEnumerable<Option> options)
        {
            return new CompanyRequest(RequestUrl, Client, options);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new ICompanyRequest Request()
        {
            return Request(null);
        }
    }
}
