namespace ServiceNow.Graph.Requests.Options
{
    /// <summary>
    /// A key value pair to be added to the request headers.
    /// </summary>
    public class HeaderOption : Option
    {
        /// <summary>
        /// Create a header option.
        /// </summary>
        /// <param name="name">The name, or key, of the header option.</param>
        /// <param name="value">The value for the header option.</param>
        public HeaderOption(string name, string value)
            : base(name, value)
        {
        }
    }
}
