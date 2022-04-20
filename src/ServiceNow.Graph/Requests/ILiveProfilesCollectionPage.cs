using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface ILiveProfilesCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<LiveProfilesCollectionPage>))]
    public interface ILiveProfilesCollectionPage : ICollectionPage<LiveProfile>
    {
        /// <summary>
        /// Gets the next page <see cref="ILiveProfilesCollectionRequest"/> instance.
        /// </summary>
        ILiveProfilesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
