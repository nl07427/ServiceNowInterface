using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow BusinessUnit (business_unit) entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class BusinessUnit : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public BusinessUnit()
        {
            ObjectType = "business_unit";
        }

        /// <summary>
        /// Parent, reference business_unit
        /// </summary>
        [JsonProperty("parent", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// Description, X100
        /// </summary>
        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        /// <summary>
        /// Name, reference X100
        /// </summary>
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Business Unit head, reference sys_user
        /// </summary>
        [JsonProperty("bu_head", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink BuHead { get; set; }

        /// <summary>
        /// Company, reference core_company
        /// </summary>
        [JsonProperty("company", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Company { get; set; }

        /// <summary>
        /// Hierarchy Level, integer
        /// </summary>
        [JsonProperty("hierarchy_level", NullValueHandling = NullValueHandling.Ignore)]
        public int? HierarchyLevel { get; set; }

        /// <summary>
        /// Domain, X32
        /// </summary>
        [JsonProperty("sys_domain", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink SysDomain { get; set; }

        /// <summary>
        /// Domain Path, X255
        /// </summary>
        [JsonProperty("sys_domain_path", NullValueHandling = NullValueHandling.Ignore)]
        public string SysDomainPath { get; set; }
    }
}
