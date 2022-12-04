using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceNow.Graph.Test.Mocks
{
    public class ExceptionHttpMessageHandler : HttpMessageHandler
    {
        private Exception exceptionToThrow;

        public ExceptionHttpMessageHandler(Exception exceptionToThrow)
        {
            this.exceptionToThrow = exceptionToThrow;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw exceptionToThrow;
        }
    }
}
