using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICatalogItemsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<CatalogItemsCollectionPage>))]
    public interface ICatalogItemsCollectionPage : ICollectionPage<CatalogItem>
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogItemsCollectionRequest"/> instance.
        /// </summary>
        ICatalogItemsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
