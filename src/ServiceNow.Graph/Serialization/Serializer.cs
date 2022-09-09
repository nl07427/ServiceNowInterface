using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Serialization
{
    /// <summary>
    /// An <see cref="ISerializer"/> implementation using the JSON.NET serializer.
    /// </summary>
    public class Serializer : ISerializer
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        /// <summary>
        /// Constructor for the serializer with defaults for the JsonSerializer settings.
        /// </summary>
        public Serializer()
            : this(
                  new JsonSerializerSettings
                  {
                      ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                      TypeNameHandling = TypeNameHandling.None,
                      DateParseHandling = DateParseHandling.None,
                      DateTimeZoneHandling =  DateTimeZoneHandling.Unspecified
                  })
        {
        }

        /// <summary>
        /// Constructor for the serializer.
        /// </summary>
        /// <param name="jsonSerializerSettings">The serializer settings to apply to the serializer.</param>
        public Serializer(JsonSerializerSettings jsonSerializerSettings)
        {
            _jsonSerializerSettings = jsonSerializerSettings;
        }

        /// <summary>
        /// Deserializes the stream to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The deserialization type.</typeparam>
        /// <param name="stream">The stream to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T DeserializeObject<T>(Stream stream)
        {
            if (stream == null)
            {
                return default;
            }

            using (var streamReader = new StreamReader(
                stream,
                Encoding.UTF8 /* encoding */,
                true /* detectEncodingFromByteOrderMarks */,
                4096 /* bufferSize */,
                true /* leaveOpen */))
            using (var textReader = new JsonTextReader(streamReader))
            {
                var jsonSerializer = JsonSerializer.Create(this._jsonSerializerSettings);
                return jsonSerializer.Deserialize<T>(textReader);
            }
        }

        /// <summary>
        /// Deserializes the JSON string to an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The deserialization type.</typeparam>
        /// <param name="inputString">The JSON string to deserialize.</param>
        /// <returns>The deserialized object.</returns>
        public T DeserializeObject<T>(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(inputString, this._jsonSerializerSettings);
        }

        /// <summary>
        /// Serializes the specified object into a JSON string.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns>The JSON string.</returns>
        public string SerializeObject(object objectToSerialize)
        {
            if (objectToSerialize == null)
            {
                return null;
            }

            if (objectToSerialize is Stream stream)
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }

            if (objectToSerialize is string stringValue)
            {
                return stringValue;
            }

            return JsonConvert.SerializeObject(objectToSerialize, _jsonSerializerSettings);
        }
    }
}
