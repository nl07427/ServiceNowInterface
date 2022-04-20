using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IUserHasRolesCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<UserHasRolesCollectionPage>))]
    public interface IUserHasRolesCollectionPage : ICollectionPage<UserHasRole>
    {
        /// <summary>
        /// Gets the next page <see cref="IUserHasRolesCollectionRequest"/> instance.
        /// </summary>
        IUserHasRolesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
