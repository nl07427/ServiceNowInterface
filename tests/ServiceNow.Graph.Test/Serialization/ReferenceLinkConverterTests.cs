using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Models.Helpers;
using ServiceNow.Graph.Serialization;
using Xunit;

namespace ServiceNow.Graph.Test.Serialization
{
    public class ReferenceLinkConverterTests
    {
        private ReferenceLinkConverter converter;

        public ReferenceLinkConverterTests()
        {
            this.converter = new ReferenceLinkConverter();
        }

        [Fact]
        public void CanConvert_ReferenceLink()
        {
            Assert.True(this.converter.CanConvert(typeof(ReferenceLink)));
        }

        [Fact]
        public void ReferenceLink_DeserializeInvalidType()
        {
            var json = "{\"link\":\"testLink\", value\":\"testValue\"}";
            var serializer = new Serializer();
            ServiceException exception = Assert.Throws<ServiceException>(() => serializer.DeserializeObject<ReferenceLink>(json));
            Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
            // todo: FIX 
            Assert.Equal(ErrorConstants.Messages.UnableToDeserializeDuration, exception.Error.ErrorDetail.DetailedMessage);
        }
    }
}
