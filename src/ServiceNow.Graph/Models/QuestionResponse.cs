using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// QuestionResponse
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class QuestionResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="Question"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public Question Result { get; set; }
    }
}
