using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// DepartmentResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class DepartmentResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Department"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public Department Result { get; set; }
    }
}
