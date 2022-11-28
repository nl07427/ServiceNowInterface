using System;
using ServiceNow.Graph.Models;
using ServiceNow.Graph.Serialization;
using Xunit;

namespace ServiceNow.Graph.Test.Models
{
    public class ModelSerializationTests
    {
        private Serializer serializer;

        public ModelSerializationTests()
        {
            this.serializer = new Serializer();
        }

        [Fact]
        public void DeserializeInvalidObjectType()
        {
            var entityId = "entityId";
            var entityModCount = 3;

            var stringToDeserialize = string.Format(
                "{{\"sys_id\":\"{0}\", \"sys_class_name\":\"invalid\", \"sys_mod_count\":\"{1}\"}}",
                entityId,
                entityModCount);

            var entity = this.serializer.DeserializeObject<Entity>(stringToDeserialize);

            Assert.NotNull(entity);
            Assert.Equal(entityId, entity.Id);
            Assert.Equal(entityModCount, entity.SysModCount);
        }

        [Fact]
        public void DeserializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var stringToDeserialize = string.Format("{{\"sys_created_on\":\"{0}\"}}", now.ToString("yyyy-MM-dd"));

            var entity = this.serializer.DeserializeObject<Entity>(stringToDeserialize);

            Assert.Equal(now.Year, entity.WhenCreated.Year);
            Assert.Equal(now.Month, entity.WhenCreated.Month);
            Assert.Equal(now.Day, entity.WhenCreated.Day);
        }
    }
}
