using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserGroupsCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<UserGroupsCollectionPage>))]
    public interface IUserGroupsCollectionPage : ICollectionPage<UserGroup>
    {
        /// <summary>
        /// Gets the next page <see cref="IUserGroupCollectionRequest"/> instance.
        /// </summary>
        IUserGroupCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
