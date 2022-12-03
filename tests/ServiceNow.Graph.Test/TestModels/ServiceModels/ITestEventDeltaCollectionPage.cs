using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Serialization;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The interface IUserEventsCollectionPage.
    /// </summary>
    [JsonConverter(typeof(InterfaceConverter<TestEventDeltaCollectionPage>))]
    public interface ITestEventDeltaCollectionPage : ICollectionPage<TestEvent>
    {
        /// <summary>
        /// Gets the next page <see cref="ITestEventDeltaCollectionPage"/> instance.
        /// </summary>
        ITestEventDeltaRequest NextPageRequest
        {
            get;
        }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString);
    }
}
