using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    /// <summary>
    /// Extensions of the ServiceNow sc_request table. Most extensions were added for the interface between
    /// One Identity Manager and ServiceNow
    /// </summary>
    public partial class CatalogRequest
    {
        private DateTimeOffset? _startDate;
        /// <summary>
        /// Contract type
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_contract_type", Required = Required.Default)]
        public string ContractType { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_first_name", Required = Required.Default)]
        public string FirstName { get; set; }

        /// <summary>
        /// Reference to sys_user table, the responsible HR representative
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_hr_name", Required = Required.Default)]
        public ReferenceLink HrRepresentative { get; set; }

        /// <summary>
        /// Incorrect information, boolean
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_incorrect_information", Required = Required.Default)]
        public bool? EmployeeInfoIncorrect { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_last_name", Required = Required.Default)]
        public string LastName { get; set; }

        /// <summary>
        /// Reference to sys_user table, manager of joiner
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_manager", Required = Required.Default)]
        public ReferenceLink Manager { get; set; }

        /// <summary>
        /// Is One Identity Manager request, boolean
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_oi_request", Required = Required.Default)]
        public bool? IsOneIdentityManagerRequest { get; set; }

        /// <summary>
        /// Manager comment, X5000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_manager_comment", Required = Required.Default)]
        public string ManagerComments { get; set; }

        /// <summary>
        /// Site code, Reference to cmn_location
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_site_code_ref", Required = Required.Default)]
        public ReferenceLink Site { get; set; }

        /// <summary>
        /// Start date, string
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_start_date", Required = Required.Default)]
        public string StartDateString { get; set; }

        /// <summary>
        /// Start date, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_ustart_date", Required = Required.Default)]
        public DateTimeOffset? StartDate
        {
            get => _startDate;
            set
            {
                if (value.HasValue)
                {
                    _startDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Job title joiner
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_title", Required = Required.Default)]
        public string JobTitle { get; set; }

        /// <summary>
        /// Employee number, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_employee_number", Required = Required.Default)]
        public string EmployeeNumber { get; set; }
    }
}
