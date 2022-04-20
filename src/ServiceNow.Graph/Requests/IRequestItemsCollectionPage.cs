using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IRequestItemsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<RequestItemsCollectionPage>))]
    public interface IRequestItemsCollectionPage : ICollectionPage<RequestItem>
    {
        /// <summary>
        /// Gets the next page <see cref="IRequestItemsCollectionRequest"/> instance.
        /// </summary>
        IRequestItemsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
