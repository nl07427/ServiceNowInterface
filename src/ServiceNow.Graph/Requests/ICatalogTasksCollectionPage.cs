using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICatalogTasksCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<CatalogTasksCollectionPage>))]
    public interface ICatalogTasksCollectionPage : ICollectionPage<CatalogTask>
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogTasksCollectionRequest"/> instance.
        /// </summary>
        ICatalogTasksCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
