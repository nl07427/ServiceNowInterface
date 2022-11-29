using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceNow.Graph.Requests;

namespace ServiceNow.Graph.Test.TestModels.ServiceModels
{
    /// <summary>
    /// The type UserEventsCollectionPage.
    /// </summary>
    public partial class TestEventDeltaCollectionPage : CollectionPage<TestEvent>, ITestEventDeltaCollectionPage
    {
        /// <summary>
        /// Gets the next page <see cref="TestEventDeltaRequest"/> instance.
        /// </summary>
        public ITestEventDeltaRequest NextPageRequest
        {
            get; private set;
        }

        /// <summary>
        /// Initializes the NextPageRequest property.
        /// </summary>
        public void InitializeNextPageRequest(IBaseClient client, string nextPageLinkString)
        {
            if (!string.IsNullOrEmpty(nextPageLinkString))
            {
                this.NextPageRequest = new TestEventDeltaRequest(
                    nextPageLinkString,
                    client,
                    null);
            }
        }
    }
}
