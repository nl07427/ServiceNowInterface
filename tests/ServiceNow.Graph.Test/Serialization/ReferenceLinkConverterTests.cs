using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
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
            var json = "{\"link\":\"testLink\", value\":\"testValue\"";
            var serializer = new Serializer();

            ServiceException exception = Assert.Throws<ServiceException>(() => serializer.DeserializeObject<ReferenceLink>(json));

            Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.UnableToDeserializeReferenceLink, exception.Error.ErrorDetail.DetailedMessage);
        }

        [Fact]
        public void ReferenceLink_DeserializeEmptyLink()
        {
            var json = "{}";
            var serializer = new Serializer();

            var referenceLink = serializer.DeserializeObject<ReferenceLink>(json);
            
            Assert.Null(referenceLink.Link);
            Assert.Null(referenceLink.Value);
        }

        [Fact]
        public void ReferenceLink_DeserializeObjectWithLinkAndValue()
        {
            var json = "{\"link\":\"testLink\", \"value\":\"testValue\"}";
            var serializer = new Serializer();

            var referenceLink = serializer.DeserializeObject<ReferenceLink>(json);

            Assert.Equal("testLink", referenceLink.Link);
            Assert.Equal("testValue", referenceLink.Value);
        }

        [Fact]
        public void ReferenceLink_DeserializeString()
        {
            var json = "\"testValue\"";
            var serializer = new Serializer();

            var referenceLink = serializer.DeserializeObject<ReferenceLink>(json);

            Assert.Equal("testValue", referenceLink.ToString());
        }
    }
}
