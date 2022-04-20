using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IRolesCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<RolesCollectionPage>))]
    public interface IRolesCollectionPage : ICollectionPage<Role>
    {
        /// <summary>
        /// Gets the next page <see cref="IRolesCollectionRequest"/> instance.
        /// </summary>
        IRolesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
