using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models;

namespace ServiceNow.Graph.Serialization
{
    /// <summary>
    /// The ReferenceLink Converter.
    /// </summary>
    public class ReferenceLinkConverter : JsonConverter
    {
        /// <summary>
        /// Check if the given object can be converted into a ReferenceLink.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <returns>True if the object is either a ReferenceLink or string type.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ReferenceLink);
        }

        /// <summary>
        /// Converts the JSON object into a ReferenceLink object
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">The object type.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer to convert the object with.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            try
            {
                var referenceLink = new ReferenceLink();
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var jObject = JObject.Load(reader);
                        referenceLink.Link = jObject.Value<string>("link");
                        referenceLink.Value = jObject.Value<string>("value");
                        break;
                    case JsonToken.String:
                        referenceLink.Value = reader.Value.ToString();
                        break;
                }

                return referenceLink;
            }
            catch (JsonSerializationException serializationException)
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            Message = ErrorConstants.Codes.GeneralException,
                            DetailedMessage = ErrorConstants.Messages.UnableToDeserializeDate
                        }
                    },
                    serializationException);
            }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is ReferenceLink referenceLink)
            {
                writer.WriteValue(referenceLink.Value);
            }
            else
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            Message = ErrorConstants.Codes.InvalidArgument,
                            DetailedMessage = ErrorConstants.Messages.InvalidTypeForReferenceLinkConverter
                        }
                    });
            }
        }
    }
}
