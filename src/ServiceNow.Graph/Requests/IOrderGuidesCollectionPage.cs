using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IOrderGuidesCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<OrderGuidesCollectionPage>))]
    public interface IOrderGuidesCollectionPage : ICollectionPage<OrderGuide>
    {
        /// <summary>
        /// Gets the next page <see cref="IOrderGuidesCollectionRequest"/> instance.
        /// </summary>
        IOrderGuidesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
