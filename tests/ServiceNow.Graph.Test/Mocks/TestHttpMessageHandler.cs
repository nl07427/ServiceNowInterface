﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace ServiceNow.Graph.Test.Mocks
{
    public class TestHttpMessageHandler : HttpMessageHandler
    {
        private Action<HttpRequestMessage> requestMessageDelegate;
        private Dictionary<string, HttpResponseMessage> responseMessages;

        public TestHttpMessageHandler(Action<HttpRequestMessage> requestMessage = null)
        {
            this.requestMessageDelegate = requestMessage ?? DefaultRequestHandler;
            this.responseMessages = new Dictionary<string, HttpResponseMessage>();
        }

        public void AddResponseMapping(string requestUrl, HttpResponseMessage responseMessage)
        {
            this.responseMessages.Add(requestUrl, responseMessage);
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            HttpResponseMessage responseMessage;

            requestMessageDelegate(request);

            if (this.responseMessages.TryGetValue(request.RequestUri.ToString(), out responseMessage))
            {
                responseMessage.RequestMessage = request;
                return Task.FromResult(responseMessage);
            }

            return Task.FromResult<HttpResponseMessage>(new HttpResponseMessage());
        }

        private void DefaultRequestHandler(HttpRequestMessage httpRequest)
        {

        }
    }
}
