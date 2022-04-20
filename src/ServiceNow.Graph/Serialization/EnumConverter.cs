using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ServiceNow.Graph.Serialization
{
    /// <summary>
    /// Handles resolving interfaces to the correct derived class during serialization/deserialization.
    /// </summary>
    public class EnumConverter : StringEnumConverter
    {
        /// <summary>
        /// Constructs a new EnumConverter.
        /// </summary>
        [Obsolete]
        public EnumConverter()
        {
            CamelCaseText = true;
        }

        /// <summary>
        /// Checks if the given type can be converted into an enum. All types
        /// can be converted.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <returns>True.</returns>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        /// <summary>
        /// Whether the object can be serialized to a request body.
        /// </summary>
        public override bool CanWrite => true;

        /// <summary>
        /// Deserializes the object to the correct type.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">The interface type.</param>
        /// <param name="existingValue">The existing value of the object being read.</param>
        /// <param name="serializer">The <see cref="JsonSerializer"/> for deserialization.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
            catch (JsonSerializationException)
            {
                // The StringEnumConverter will throw a JsonSerializationException if the enum value doesn't exist.
                // Swallow the exception and return null in this case. The actual value will be in the additional
                // data property bag after deserialization.
            }

            return null;
        }
    }
}
