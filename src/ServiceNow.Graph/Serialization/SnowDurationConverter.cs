using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models.Helpers;

namespace ServiceNow.Graph.Serialization
{
    /// <summary>
    /// The SnowDurationConverter Converter.
    /// </summary>
    public class SnowDurationConverter : JsonConverter
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0);
        /// <summary>
        /// Check if the given object can be converted into a SnowDurationConverter.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <returns>True</returns>
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        /// <summary>
        /// Converts the JSON object into a SnowDurationConverter object
        /// </summary>
        /// <param name="reader">The <see cref="JsonWriter"/> to read from.</param>
        /// <param name="objectType">The object type.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer to convert the object with.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String && string.IsNullOrEmpty((string)reader.Value))
            {
                return new SnowDuration(1970,1,1,0,0,0);
            }

            try
            {
                var dateTime = (DateTime) serializer.Deserialize(reader, typeof(DateTime));

                return new SnowDuration(dateTime);
            }
            catch (JsonSerializationException serializationException)
            {
                throw new ServiceException(
                    new Error
                    {
                        ErrorDetail = new ErrorDetail()
                        {
                            Message = ErrorConstants.Codes.GeneralException,
                            DetailedMessage = ErrorConstants.Messages.UnableToDeserializeDuration
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
            if (value != null)
            {
                if (value is SnowDuration timeSpan)
                {
                    writer.WriteValue(Epoch.Add(timeSpan.TimeSpan).ToString("yyyy-MM-dd hh:mm:ss"));
                }
                else
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail()
                            {
                                Message = ErrorConstants.Codes.InvalidArgument,
                                DetailedMessage = ErrorConstants.Messages.InvalidTypeForDateConverter
                            }
                        });
                }
            }
            else
            {
                writer.WriteValue("");
            }
        }
    }
}
