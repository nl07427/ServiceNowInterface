using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;
using ServiceNow.Graph.Test.TestModels;
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

        [Fact]
        public void ReferenceLink_SerializeObject()
        {
            var referenceLink = new ReferenceLink
            {
                Link = "testLink",
                Value = "testValue"
            };
            var serializer = new Serializer();
            var expectedJson = "\"testValue\"";

            var json = serializer.SerializeObject(referenceLink);

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void ReferenceLink_SerializeInvalidObject()
        {
            var referenceLink = new WrongTypeWithReferenceLinkConverter();
            var serializer = new Serializer();

            ServiceException exception = Assert.Throws<ServiceException>(() => serializer.SerializeObject(referenceLink));

            Assert.Equal(ErrorConstants.Codes.InvalidArgument, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.InvalidTypeForReferenceLinkConverter, exception.Error.ErrorDetail.DetailedMessage);
        }
    }
}
