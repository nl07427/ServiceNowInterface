using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface IAttachmentsCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<AttachmentsCollectionPage>))]
    public interface IAttachmentsCollectionPage : ICollectionPage<Attachment>
    {
        /// <summary>
        /// Gets the next page <see cref="IAttachmentsCollectionRequest"/> instance.
        /// </summary>
        IAttachmentsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
