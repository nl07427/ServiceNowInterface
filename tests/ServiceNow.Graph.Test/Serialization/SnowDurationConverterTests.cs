using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models.Helpers;
using ServiceNow.Graph.Serialization;
using Xunit;

namespace ServiceNow.Graph.Test.Serialization
{
    public class SnowDurationConverterTests
    {
        private SnowDurationConverter converter;

        public SnowDurationConverterTests()
        {
            this.converter = new SnowDurationConverter();
        }

        [Fact]
        public void CanConvert_SnowDuration()
        {
            Assert.True(this.converter.CanConvert(typeof(SnowDuration)));
        }

        [Fact]
        public void SnowDuration_DeserializeInvalidType()
        {
            var json = "\"ABCD\"";
            var serializer = new Serializer();
            ServiceException exception = Assert.Throws<ServiceException>(() => serializer.DeserializeObject<SnowDuration>(json));
            Assert.Equal(ErrorConstants.Codes.GeneralException, exception.Error.ErrorDetail.Message);
            Assert.Equal(ErrorConstants.Messages.UnableToDeserializeDuration, exception.Error.ErrorDetail.DetailedMessage);
        }

        [Fact]
        public void SnowDuration_DeserializeEmptyDate()
        {
            var json = "\"\"";
            var serializer = new Serializer();
            var derivedType = serializer.DeserializeObject<SnowDuration>(json);
            var expectedDuration = new SnowDuration(1970, 1, 1, 0, 0, 0);
            Assert.Equal(expectedDuration.TimeSpan.Hours, derivedType.TimeSpan.Hours);
            Assert.Equal(expectedDuration.TimeSpan.Minutes, derivedType.TimeSpan.Minutes);
            Assert.Equal(expectedDuration.TimeSpan.Seconds, derivedType.TimeSpan.Seconds);
        }

        [Fact]
        public void SnowDuration_CanDeserialize()
        {
            var json = "\"1970-01-01T02:00:00\"";
            var serializer = new Serializer();
            var derivedType = serializer.DeserializeObject<SnowDuration>(json);
            Assert.NotNull(derivedType);
            Assert.Equal(2, derivedType.TimeSpan.Hours);
        }

        [Fact]
        public void SnowDuration_CanSerialize()
        {
            var snowDuration = new SnowDuration(2000, 5, 7, 1, 2, 3);
            var expectedJson = "\"2000-05-07 01:02:03\"";
            var serializer = new Serializer();

            var json = serializer.SerializeObject(snowDuration);

            Assert.Equal(expectedJson, json);
        }
    }
}
