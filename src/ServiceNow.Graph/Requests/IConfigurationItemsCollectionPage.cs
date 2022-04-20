using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IConfigurationItemsCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<ConfigurationItemsCollectionPage>))]
    public interface IConfigurationItemsCollectionPage : ICollectionPage<ConfigurationItem>
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogItemOptionMtomsCollectionRequest"/> instance.
        /// </summary>
        IConfigurationItemsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
