using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models.Helpers
{
    /// <summary>
    /// Custom Date model for serialization
    /// </summary>
    [JsonConverter(typeof(DateConverter))]
    public class Date
    {
        /// <summary>
        /// Internal Date constructor
        /// </summary>
        /// <param name="dateTime"></param>
        internal Date(DateTime dateTime)
        {
            DateTime = dateTime;
        }

        /// <summary>
        /// Create a new Date object from a year, month, and day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day of the month.</param>
        public Date(int year, int month, int day)
            : this(new DateTime(year, month, day))
        {
        }

        /// <summary>
        /// The DateTime object.
        /// </summary>
        internal DateTime DateTime { get; set; }

        /// <summary>
        /// The date's year.
        /// </summary>
        public int Year => DateTime.Year;

        /// <summary>
        /// The date's month.
        /// </summary>
        public int Month => DateTime.Month;

        /// <summary>
        /// The date's day.
        /// </summary>
        public int Day => DateTime.Day;

        /// <summary>
        /// Convert the date to a string.
        /// </summary>
        /// <returns>The string value of the date in the format "yyyy-MM-dd".</returns>
        public override string ToString()
        {
            return DateTime.ToString("yyyy-MM-dd");
        }
    }
}
