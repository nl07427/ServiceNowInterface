using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Requests.Options;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace ServiceNow.Graph.Test.Requests
{
    public class BaseRequestTests : RequestTestBase
    {
        [Fact]
        public void BaseRequest_InitializeWithEmptyBaseUrl()
        {
            ServiceException exception = Assert.Throws<ServiceException>(() => new BaseRequest(null, this.baseClient));
            Assert.Equal(ErrorConstants.Codes.InvalidRequest, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.BaseUrlMissing, exception.Error.ErrorDetail.DetailedMessage);
        }

        [Theory]
        [InlineData("contains(subject, '#')", "contains%28subject%2C%20%27%23%27%29")]
        [InlineData("contains(subject, '?')", "contains%28subject%2C%20%27%3F%27%29")]
        [InlineData("contains(subject,'Überweisung')", "contains%28subject%2C%27%C3%9Cberweisung%27%29")]
        [InlineData("contains%28subject%2C%27%C3%9Cberweisung%27%29", "contains%28subject%2C%27%C3%9Cberweisung%27%29")]//ensure we do not double encode parameters if already encoded
        public void BaseRequest_InitializeWithQueryOptionsWillUrlEncodeQueryOptions(string filterClause, string expectedQueryParam)
        {
            // Arrange
            var requestUrl = string.Concat(this.baseUrl, "/users");
            var options = new List<Option>
            {
                new QueryOption("$filter", filterClause),
            };
            var expectedUrl = $"https://localhost/v1.0/users?$filter={expectedQueryParam}";

            // Act
            var baseRequest = new BaseRequest(requestUrl, this.baseClient, options);
            var requestMessage = baseRequest.GetHttpRequestMessage();


            Assert.Equal(new Uri(requestUrl), new Uri(baseRequest.RequestUrl));
            Assert.Equal(1, baseRequest.QueryOptions.Count);
            Assert.Equal(expectedUrl, requestMessage.RequestUri.AbsoluteUri);
        }

    }
}
