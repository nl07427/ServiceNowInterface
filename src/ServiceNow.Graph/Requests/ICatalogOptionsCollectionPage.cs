using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICatalogOptionsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<CatalogOptionsCollectionPage>))]
    public interface ICatalogOptionsCollectionPage : ICollectionPage<CatalogOption>
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogOptionsCollectionRequest"/> instance.
        /// </summary>
        ICatalogOptionsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
