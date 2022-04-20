using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUsersCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<UsersCollectionPage>))]
    public interface IUsersCollectionPage : ICollectionPage<User>
    {
        /// <summary>
        /// Gets the next page <see cref="IUsersCollectionRequest"/> instance.
        /// </summary>
        IUsersCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
