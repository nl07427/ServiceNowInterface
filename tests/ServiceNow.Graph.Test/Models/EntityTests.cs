using System.Linq;
using System.Reflection;
using ServiceNow.Graph.Models;
using Xunit;

namespace ServiceNow.Graph.Test.Models
{
    public class EntityTests
    {
        [Fact]
        public void AbstractEntity_DefaultConstructorGeneration()
        {
            var entityType = typeof(Entity);
            var constructors = entityType.GetConstructors(
                BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);

            Assert.Single(constructors);

            var defaultConstructor = constructors.First();
            Assert.False(defaultConstructor.IsPrivate);
            Assert.False(defaultConstructor.IsPublic);
            Assert.False(defaultConstructor.IsStatic);
            Assert.False(defaultConstructor.GetParameters().Any());
        }
    }
}
