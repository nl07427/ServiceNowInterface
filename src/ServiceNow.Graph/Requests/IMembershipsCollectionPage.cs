using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IMembershipsCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<MembershipsCollectionPage>))]
    public interface IMembershipsCollectionPage : ICollectionPage<UserGroupMembership>
    {
        /// <summary>
        /// Gets the next page <see cref="IMembershipsCollectionRequest"/> instance.
        /// </summary>
        IMembershipsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
