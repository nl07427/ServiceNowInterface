using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    public partial class User
    {
        /// <summary>
        /// Location , reference to cmn_location table
        /// </summary>
        [JsonProperty(PropertyName = "u_location", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink BelLocation { get; set; }

        /// <summary>
        /// Office, X256
        /// </summary>
        [JsonProperty(PropertyName = "u_office", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Office { get; set; }

        /// <summary>
        /// User Sell Force
        /// </summary>
        [JsonProperty(PropertyName = "u_sellforceuser", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? UserSellForce { get; set; }

        /// <summary>
        /// Contract End Date
        /// </summary>
        [JsonProperty(PropertyName = "u_contract_end_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ContractEndDate { get; set; }

        /// <summary>
        /// Contract Start Date
        /// </summary>
        [JsonProperty(PropertyName = "u_contract_start_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ContractStartDate { get; set; }

        /// <summary>
        /// Employee type, X40
        /// </summary>
        [JsonProperty(PropertyName = "u_employee_status", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string EmployeeType { get; set; }

        /// <summary>
        /// Contract type, X40
        /// </summary>
        [JsonProperty(PropertyName = "u_contract_type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ContractType { get; set; }

        /// <summary>
        /// Partner Company
        /// </summary>
        [JsonProperty(PropertyName = "u_partner_company", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string PartnerCompany { get; set; }

        /// <summary>
        /// Job family label (Business Unit)
        /// </summary>
        [JsonProperty(PropertyName = "u_job_family_label", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink JobFamilyLabel { get; set;  }
    }
}
