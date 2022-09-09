using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models.Helpers
{
    /// <summary>
    /// Custom TimeSpan model for serialization
    /// </summary>
    [JsonConverter(typeof(SnowDurationConverter))]
    public class SnowDuration
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0);
        /// <summary>
        /// Internal Date constructor
        /// </summary>
        /// <param name="dateTime"></param>
        internal SnowDuration(DateTime SecondDate)
        {
            TimeSpan = SecondDate - Epoch;
        }

        /// <summary>
        /// Create a new Date object from a year, month, and day.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <param name="month">The month.</param>
        /// <param name="day">The day of the month.</param>
        public SnowDuration(int year, int month, int day, int hours, int minutes, int seconds)
            : this(new DateTime(year, month, day, hours, minutes, seconds))
        {
        }

        /// <summary>
        /// The TimeSpan object.
        /// </summary>
        internal TimeSpan TimeSpan { get; set; }

        /// <summary>
        /// The days
        /// </summary>
        public int Days => TimeSpan.Days;

        /// <summary>
        /// The hours.
        /// </summary>
        public int Hours => TimeSpan.Hours;

        /// <summary>
        /// The minutes
        /// </summary>
        public int Minutes => TimeSpan.Minutes;

        /// <summary>
        /// The seconds
        /// </summary>
        public int Seconds => TimeSpan.Seconds;

        /// <summary>
        /// Convert the date to a string.
        /// </summary>
        /// <returns>The string value of the date in the format "yyyy-MM-dd".</returns>
        public override string ToString()
        {
            return $"{Days} days {Hours:D2}:{Minutes:D2}:{Seconds:D2}";
        }
    }
}
