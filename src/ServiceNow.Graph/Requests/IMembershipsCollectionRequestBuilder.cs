using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IMembershipsCollectionRequestBuilder.
    /// </summary>
    public interface IMembershipsCollectionRequestBuilder : IBaseRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IMembershipsCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IMembershipsCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Gets an <see cref="IMembershipRequestBuilder"/> for the specified group membership.
        /// </summary>
        /// <param name="id">The id (sys_id) for group membership.</param>
        /// <returns>The <see cref="IMembershipRequestBuilder"/>.</returns>
        IMembershipRequestBuilder this[string id] { get; }
    }
}
