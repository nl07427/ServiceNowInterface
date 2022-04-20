using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// CompanyResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CompanyResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Company"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public Company Result { get; set; }
    }
}
