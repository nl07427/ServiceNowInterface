using System.Net.Http;
using System.Text;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="ISerializer"/>
    /// </summary>
    public static class SerializerExtensions
    {
        /// <summary>
        /// Serialize an object into a <see cref="HttpContent"/> object 
        /// </summary>
        /// <param name="serializer"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static HttpContent SerializeAsJsonContent(this ISerializer serializer, object source)
        {
            var stringContent = serializer.SerializeObject(source);
            return new StringContent(stringContent, Encoding.UTF8, "application/json");
        }
    }
}
