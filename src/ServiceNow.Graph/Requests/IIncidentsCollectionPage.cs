using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IIncidentsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<IncidentsCollectionPage>))]
    public interface IIncidentsCollectionPage : ICollectionPage<Incident>
    {
        /// <summary>
        /// Gets the next page <see cref="IIncidentsCollectionRequest"/> instance.
        /// </summary>
        IIncidentsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
