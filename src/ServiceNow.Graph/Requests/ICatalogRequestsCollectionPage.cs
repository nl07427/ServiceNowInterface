using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICatalogRequestsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<CatalogRequestsCollectionPage>))]
    public interface ICatalogRequestsCollectionPage : ICollectionPage<CatalogRequest>
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogRequestsCollectionRequest"/> instance.
        /// </summary>
        ICatalogRequestsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
