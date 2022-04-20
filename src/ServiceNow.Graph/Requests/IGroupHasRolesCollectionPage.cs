using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IGroupHasRolesCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<GroupHasRolesCollectionPage>))]
    public interface IGroupHasRolesCollectionPage : ICollectionPage<GroupHasRole>
    {
        /// <summary>
        /// Gets the next page <see cref="IGroupHasRolesCollectionRequest"/> instance.
        /// </summary>
        IGroupHasRolesCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
