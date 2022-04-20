using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// ILocationsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<LocationsCollectionPage>))]
    public interface ILocationsCollectionPage : ICollectionPage<Location>
    {
        /// <summary>
        /// Gets the next page <see cref="ILocationsCollectionRequest"/> instance.
        /// </summary>
        ILocationsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
