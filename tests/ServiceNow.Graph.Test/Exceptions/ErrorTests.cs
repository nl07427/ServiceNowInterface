using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Serialization;
using Xunit;

namespace ServiceNow.Graph.Test.Exceptions
{
    public class ErrorTests
    {
        private const string jsonErrorResponseBody = "{\"error\":{\"error\":{\"message\":\"BadRequest\",\"detail\":\"Resource not found for the segment 'mer'.\"},\"clientRequestId\":\"requestId\",\"unexpected-property\":\"unexpected-property-value\",\"status\":\"status\"}}";
        private const string jsonErrorResponseBodyNestedNull = "{\"error\":{\"clientRequestId\":\"requestId\",\"unexpected-property\":null}, \"response-property\":\"property-value\"}";
        private Serializer serializer;

        public ErrorTests()
        {
            this.serializer = new Serializer();
        }

        [Fact]
        public void VerifyToString()
        {
            var errorDetail = new ErrorDetail()
            {
                Message = "errorDetailMessage",
                DetailedMessage = "errorDetailDetailedMessage",
            };

            var additionalData = new Dictionary<string, object>()
            {
                { "key", "value" }
            };

            var error = new Error
            {
                ErrorDetail = errorDetail,
                ErrorStatus = "errorStatus",
                ClientRequestId = "clientRequestId",
                AdditionalData = additionalData
            };

            var errorStringBuilder = new StringBuilder();
            errorStringBuilder.Append("Message: errorDetailMessage");
            errorStringBuilder.Append(Environment.NewLine);
            errorStringBuilder.Append("Detailed error message: errorDetailDetailedMessage");
            errorStringBuilder.Append(Environment.NewLine);

            Assert.Equal(errorStringBuilder.ToString(), error.ToString());
        }

        [Fact]
        public void Validate_ErrorObjectDeserializes()
        {
            Error error = this.serializer.DeserializeObject<ErrorResponse>(jsonErrorResponseBody).Error;

            Assert.NotNull(error);
            Assert.Equal("BadRequest", error.ErrorDetail.Message);
            Assert.Equal("Resource not found for the segment 'mer'.", error.ErrorDetail.DetailedMessage);
            Assert.Null(error.ClientRequestId);
            Assert.NotNull(error.AdditionalData);
            Assert.Equal("unexpected-property-value", error.AdditionalData["unexpected-property"].ToString());
        }

        [Fact]
        public void Validate_ErrorResponseObjectWithNestedNullDeserializes()
        {
            ErrorResponse errorResponse = this.serializer.DeserializeObject<ErrorResponse>(jsonErrorResponseBodyNestedNull);

            Assert.NotNull(errorResponse);
            Assert.Null(errorResponse.Error.AdditionalData["unexpected-property"]);
            Assert.Equal("property-value", errorResponse.AdditionalData["response-property"].ToString());
        }
    }
}
