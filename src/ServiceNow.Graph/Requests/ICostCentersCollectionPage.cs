using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ICostCentersCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<CostCentersCollectionPage>))]
    public interface ICostCentersCollectionPage : ICollectionPage<CostCenter>
    {
        /// <summary>
        /// Gets the next page <see cref="ICostCentersCollectionRequest"/> instance.
        /// </summary>
        ICostCentersCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
