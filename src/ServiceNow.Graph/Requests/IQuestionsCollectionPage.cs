using Newtonsoft.Json;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// IQuestionsCollectionPage
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<QuestionsCollectionPage>))]
    public interface IQuestionsCollectionPage : ICollectionPage<Question>
    {
        /// <summary>
        /// Gets the next page <see cref="IQuestionsCollectionRequest"/> instance.
        /// </summary>
        IQuestionsCollectionRequest NextPageRequest { get; }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
