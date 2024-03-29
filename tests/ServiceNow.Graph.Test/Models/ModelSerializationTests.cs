﻿using System;
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

        [Fact]
        public void SerializeAndDeserializeKnownEnumValue()
        {
            var now = DateTime.UtcNow;

            var entity = new Entity
            {
                ObjectType = "servicenow.graph.entity",
                Id = "entity",
                SysModCount = 3,
                WhenUpdated = new DateTime(now.Year, now.Month, now.Day),
            };

            var expectedSerializedStream = string.Format(
                "{{\"sys_class_name\":\"servicenow.graph.entity\",\"sys_created_on\":\"{0}\",\"sys_id\":\"{1}\",\"sys_mod_count\":{2},\"sys_updated_on\":\"{3}\"}}",
                "0001-01-01T00:00:00",
                entity.Id,
                entity.SysModCount,
                now.ToString("yyyy-MM-ddT00:00:00"));

            var serializedValue = this.serializer.SerializeObject(entity);

            Assert.Equal(expectedSerializedStream, serializedValue);

            var newEntity = this.serializer.DeserializeObject<Entity>(serializedValue);

            Assert.NotNull(newEntity);
            Assert.Equal(entity.Id, newEntity.Id);
            Assert.Equal(entity.SysModCount, newEntity.SysModCount);
            Assert.Null(entity.CreatedBy);
        }

        [Fact]
        public void SerializeDateValue()
        {
            var now = DateTimeOffset.UtcNow;

            var expectedSerializedString = string.Format("{{\"sys_created_on\":\"{0}\",\"sys_updated_on\":\"{1}\"}}",
                now.ToString("yyyy-MM-ddT00:00:00"),
                "0001-01-01T00:00:00");

            var entity = new Entity
            {
                WhenCreated = new DateTime(now.Year, now.Month, now.Day),
            };

            var serializedString = this.serializer.SerializeObject(entity);

            Assert.Equal(expectedSerializedString, serializedString);
        }
    }
}
