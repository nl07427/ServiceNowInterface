using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// The type RoleHasRoleResponse.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RoleHasRoleResponse
    {
        /// <summary>
        /// Gets or sets the <see cref="RoleHasRole"/> value.
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "result", Required = Required.Default)]
        public RoleHasRole Result { get; set; }
    }
}
