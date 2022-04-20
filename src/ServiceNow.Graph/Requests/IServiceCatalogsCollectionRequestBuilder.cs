using System.Collections.Generic;
using ServiceNow.Graph.Requests.Options;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IServiceCatalogsCollectionRequestBuilder
    /// </summary>
    public interface IServiceCatalogsCollectionRequestBuilder : IBaseRequestBuilder
    {
        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <returns>The built request.</returns>
        IServiceCatalogsCollectionRequest Request();

        /// <summary>
        /// Builds the request.
        /// </summary>
        /// <param name="options">The query and header options for the request.</param>
        /// <returns>The built request.</returns>
        IServiceCatalogsCollectionRequest Request(IEnumerable<Option> options);

        /// <summary>
        /// Single entity request builder
        /// </summary>
        /// <param name="id">The id (sys_id) of the entity.</param>
        /// <returns>The single entity request builder.</returns>
        IServiceCatalogRequestBuilder this[string id] { get; }
    }
}
