using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICatalogsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<ServiceCatalogsCollectionPage>))]
    public interface IServiceCatalogsCollectionPage : ICollectionPage<ServiceCatalog>
    {
        /// <summary>
        /// Gets the next page <see cref="IServiceCatalogsCollectionRequest"/> instance.
        /// </summary>
        IServiceCatalogsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
