using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.Mocks
{
    public class MockCustomHttpProvider : IHttpProvider
    {
        private MockSerializer serializer = new MockSerializer();
        internal HttpClient httpClient;
        public MockCustomHttpProvider(HttpMessageHandler httpMessageHandler)
        {
            httpClient = new HttpClient(httpMessageHandler);
        }
        public ISerializer Serializer => serializer.Object;

        public TimeSpan OverallTimeout
        {
            get
            {
                return this.httpClient.Timeout;
            }

            set
            {
                try
                {
                    this.httpClient.Timeout = value;
                }
                catch (InvalidOperationException exception)
                {
                    ErrorDetail errorDetail = new ErrorDetail
                    {
                        Message = ErrorConstants.Codes.NotAllowed,
                        DetailedMessage = ErrorConstants.Messages.OverallTimeoutCannotBeSet,
                    };
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = errorDetail
                        },
                        exception);
                }
            }
        }

        public void Dispose()
        {
            if (this.httpClient != null)
            {
                this.httpClient.Dispose();
            }
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.SendAsync(request, HttpCompletionOption.ResponseContentRead, CancellationToken.None);
        }

        public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return await this.httpClient.SendAsync(request, completionOption, cancellationToken);
        }
    }
}
