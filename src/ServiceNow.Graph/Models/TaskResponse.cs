using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type TaskResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class TaskResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Task"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public Task Result { get; set; }
    }
}
