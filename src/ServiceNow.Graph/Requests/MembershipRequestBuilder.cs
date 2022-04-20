using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IMembershipRequestBuilder.
    /// </summary>
    public class MembershipRequestBuilder : EntityRequestBuilder, IMembershipRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public MembershipRequestBuilder(string requestUrl,
            IBaseClient client)
            : base(requestUrl, client)
        {
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        public new IMembershipRequest Request()
        {
            return Request(null);
        }

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        public new IMembershipRequest Request(IEnumerable<Option> options)
        {
            return new MembershipRequest(RequestUrl, Client, options);
        }
    }
}
