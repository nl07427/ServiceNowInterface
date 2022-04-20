using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// GroupHasRole response object
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class GroupHasRoleResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="GroupHasRole"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public GroupHasRole Result { get; set; }
    }
}
