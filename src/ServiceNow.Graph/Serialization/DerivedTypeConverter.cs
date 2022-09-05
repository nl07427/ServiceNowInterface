using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceNow.Graph.Exceptions;

namespace ServiceNow.Graph.Serialization
{
    /// <summary>
    /// Handles resolving interfaces to the correct derived class during serialization/deserialization.
    /// </summary>
    public class DerivedTypeConverter : JsonConverter
    {
        /// <summary>
        /// Checks if the given object can be converted. In this instance, all object can be converted.
        /// </summary>
        /// <param name="objectType">The type of the object to convert.</param>
        /// <returns>True</returns>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        /// <summary>
        /// Checks if the entity supports write. Currently no derived types support write.
        /// </summary>
        public override bool CanWrite => false;

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
            var jObject = JObject.Load(reader);

            var instance = Create(objectType.AssemblyQualifiedName, /* typeAssembly */ null);

            if (instance == null)
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            DetailedMessage = string.Format(
                                ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString,
                                objectType.AssemblyQualifiedName),
                            Message = ErrorConstants.Codes.GeneralException,
                        }
                    });
            }

            using (var objectReader = GetObjectReader(reader, jObject))
            {
                serializer.Populate(objectReader, instance);
                return instance;
            }
        }

        /// <summary>
        /// Not yet implemented
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private object Create(string typeString, Assembly typeAssembly)
        {
            var type = typeAssembly != null ? typeAssembly.GetType(typeString) : Type.GetType(typeString);

            return Create(type);
        }

        private object Create(Type type)
        {
            if (type == null)
            {
                return null;
            }

            try
            {
                // Find the default constructor. Abstract entity classes use non-public constructors.
                var constructorInfo = type.GetTypeInfo().DeclaredConstructors.FirstOrDefault(
                    constructor => constructor.GetParameters().Length == 0 && !constructor.IsStatic);

                if (constructorInfo == null)
                {
                    return null;
                }

                return constructorInfo.Invoke(Array.Empty<object>());
            }
            catch (Exception exception)
            {
                throw new ServiceException(
                    new Error()
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            DetailedMessage = string.Format(ErrorConstants.Messages.UnableToCreateInstanceOfTypeFormatString, type.FullName),
                            Message = ErrorConstants.Codes.GeneralException,
                        }
                    }, exception);
            }
        }

        private static JsonReader GetObjectReader(JsonReader originalReader, JObject jObject)
        {
            var objectReader = jObject.CreateReader();

            objectReader.Culture = originalReader.Culture;
            objectReader.DateParseHandling = originalReader.DateParseHandling;
            objectReader.DateTimeZoneHandling = originalReader.DateTimeZoneHandling;
            objectReader.FloatParseHandling = originalReader.FloatParseHandling;

            // This reader is only for a single token. Don't dispose the stream after.
            objectReader.CloseInput = false;

            return objectReader;
        }
    }
}
