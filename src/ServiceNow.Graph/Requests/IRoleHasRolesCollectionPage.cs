using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IRoleHasRolesCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<RoleHasRolesCollectionPage>))]
    public interface IRoleHasRolesCollectionPage : ICollectionPage<RoleHasRole>
    {
        /// <summary>
        /// Gets the next page <see cref="IRoleHasRolesCollectionRequest"/> instance.
        /// </summary>
        IRoleHasRolesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
