namespace ServiceNow.Graph.Requests.Options
{
    /// <summary>
    /// A query option to be added to the request.
    /// </summary>
    public class QueryOption : Option
    {
        /// <summary>
        /// Create a query option.
        /// </summary>
        /// <param name="name">The name of the query option, or parameter.</param>
        /// <param name="value">The value of the query option.</param>
        public QueryOption(string name, string value)
            : base(name, value)
        {
        }
    }
}
