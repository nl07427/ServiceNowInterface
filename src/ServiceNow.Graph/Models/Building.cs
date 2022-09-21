using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow Building (cmn_building) entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Building : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Building()
        {
            ObjectType = "cmn_building";
        }

        /// <summary>
        /// Contact, reference sys_user
        /// </summary>
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Contact { get; set; }

        /// <summary>
        /// Floors, integer
        /// </summary>
        [JsonProperty("floors", NullValueHandling = NullValueHandling.Ignore)]
        public int? Floors { get; set; }

        /// <summary>
        /// Location, reference cmn_location
        /// </summary>
        [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Location { get; set; }

        /// <summary>
        /// Name, reference X100
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Notes, X4000
        /// </summary>
        [JsonProperty("notes", NullValueHandling = NullValueHandling.Ignore)]
        public string Notes { get; set; }
    }
}
