using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Models.Helpers;

namespace ServiceNow.Graph.Serialization
{
    /// <summary>
    /// The Date Converter.
    /// </summary>
    public class DateConverter : JsonConverter
    {
        /// <summary>
        /// Check if the given object can be converted into a Date.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <returns>True if the object is a Date type.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Date);
        }

        /// <summary>
        /// Converts the JSON object into a Date object
        /// </summary>
        /// <param name="reader">The <see cref="JsonWriter"/> to read from.</param>
        /// <param name="objectType">The object type.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The serializer to convert the object with.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var dateTime = (DateTime)serializer.Deserialize(reader, typeof(DateTime));

                return new Date(dateTime);
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
            if (value is Date date)
            {
                writer.WriteValue(date.ToString());
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
    }
}
