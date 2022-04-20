using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface ICatalogItemOptionMtomsCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<CatalogItemOptionMtomsCollectionPage>))]
    public interface ICatalogItemOptionMtomsCollectionPage : ICollectionPage<CatalogItemOptionMtom>
    {
        /// <summary>
        /// Gets the next page <see cref="ICatalogItemOptionMtomsCollectionRequest"/> instance.
        /// </summary>
        ICatalogItemOptionMtomsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
