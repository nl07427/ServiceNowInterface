using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IOrderGuidesCollectionRequestBuilder
    /// </summary>
    public interface IOrderGuidesCollectionRequestBuilder : IBaseRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IOrderGuidesCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IOrderGuidesCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Single entity request builder
        /// </summary>
        /// <param name="id">The id (sys_id) of the entity.</param>
        /// <returns>The single entity request builder.</returns>
        IOrderGuideRequestBuilder this[string id] { get; }
    }
}
