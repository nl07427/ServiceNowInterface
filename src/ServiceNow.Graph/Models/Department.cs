using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow cmn_department table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Department : Entity
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Department()
        {
            ObjectType = "cmn_department";
        }

        /// <summary>
        /// Business unit, business_unit reference
        /// </summary>
        [JsonProperty(PropertyName = "business_unit", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink BusinessUnit { get; set; }

        /// <summary>
        /// Company, reference company
        /// </summary>
        [JsonProperty(PropertyName = "company", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Company { get; set; }

        /// <summary>
        /// Cost center, cmn_cost_center reference
        /// </summary>
        [JsonProperty(PropertyName = "cost_center", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CostCenter { get; set; }

        /// <summary>
        /// Department head, reference sys_user
        /// </summary>
        [JsonProperty(PropertyName = "dept_head", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DeptHead { get; set; }

        /// <summary>
        /// Description, X1000
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Head count, int
        /// </summary>
        [JsonProperty(PropertyName = "head_count", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? HeadCount { get; set; }

        /// <summary>
        /// Department  id, X40
        /// </summary>
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DepartmentId { get; set; }

        /// <summary>
        /// Department name, X100
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Parent department
        /// </summary>
        [JsonProperty(PropertyName = "parent", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// Primary contact, sys_user reference
        /// </summary>
        [JsonProperty(PropertyName = "primary_contact", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink PrimaryContact { get; set; }
    }
}
