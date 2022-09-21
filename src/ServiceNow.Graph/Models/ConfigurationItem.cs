using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow ConfigurationItem (cmdb_ci) entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class ConfigurationItem : BaseConfigurationItem
    {
        private DateTimeOffset? _attestedDate;
        private DateTimeOffset? _firstDiscovered;
        private DateTimeOffset? _lastDiscovered;
        private DateTimeOffset? _startDate;

        /// <summary>
        /// Default constructor
        /// </summary>
        public ConfigurationItem()
        {
        }
        /// <summary>
        /// Attested date
        /// </summary>
        [JsonProperty(PropertyName = "attested_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? AttestedDate
        {
            get => _attestedDate;
            set
            {
                if (value.HasValue)
                {
                    _attestedDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Operational status
        /// </summary>
        [JsonProperty(PropertyName = "operational_status", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string OperationalStatus { get; set; }

        /// <summary>
        /// Attestation score
        /// </summary>
        [JsonProperty(PropertyName = "attestation_score", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AttestationScore { get; set; }

        /// <summary>
        /// Attestation status, X40
        /// </summary>
        [JsonProperty(PropertyName = "attestation_status", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AttestationStatus { get; set; }

        /// <summary>
        /// Name of primary (most trusted) discovery source, X40
        /// </summary>
        [JsonProperty(PropertyName = "discovery_source", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DiscoverySource { get; set; }

        /// <summary>
        /// Date and time instance was initially discovered
        /// </summary>
        [JsonProperty(PropertyName = "first_discovered", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? FirstDiscovered
        {
            get => _firstDiscovered;
            set
            {
                if (value.HasValue)
                {
                    _firstDiscovered = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Full path name of domain to which the instance belongs, X255
        /// </summary>
        [JsonProperty(PropertyName = "fqdn", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Fqdn { get; set; }

        /// <summary>
        /// Reference to sys_user_group
        /// </summary>
        [JsonProperty(PropertyName = "change_control", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ApprovalGroup { get; set; }

        /// <summary>
        /// Reference to business_unit
        /// </summary>
        [JsonProperty(PropertyName = "business_unit", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink BusinessUnit { get; set; }

        /// <summary>
        /// Reference to life_cycle_stage
        /// </summary>
        [JsonProperty(PropertyName = "life_cycle_stage", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink LifeCycleStage { get; set; }

        /// <summary>
        /// Reference to life_cycle_stage_status
        /// </summary>
        [JsonProperty(PropertyName = "life_cycle_stage_status", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink LifeCycleStageStatus { get; set; }

        /// <summary>
        /// Reference to schedule table
        /// </summary>
        [JsonProperty(PropertyName = "maintenance_schedule", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink MaintenanceSchedule { get; set; }

        /// <summary>
        /// Reference to sys_user table
        /// </summary>
        [JsonProperty(PropertyName = "attested_by", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink AttestedBy { get; set; }

        /// <summary>
        /// Name of the DNS domain to which the instance belongs, X255
        /// </summary>
        [JsonProperty(PropertyName = "dns_domain", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DnsDomain { get; set; }

        /// <summary>
        /// Name of Subcategory applicable to the instance
        /// </summary>
        [JsonProperty(PropertyName = "subcategory", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Subcategory { get; set; }

        /// <summary>
        /// Fit (how deployed) and function (purpose) of the instance , X4000
        /// </summary>
        [JsonProperty(PropertyName = "short_description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Reference to sys_user_group
        /// </summary>
        [JsonProperty(PropertyName = "managed_by_group", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ManagedByGroup { get; set; }

        /// <summary>
        /// Indicates whether the instance can print
        /// </summary>
        [JsonProperty(PropertyName = "can_print", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? CanPrint { get; set; }

        /// <summary>
        /// Date and time instance was last discovered
        /// </summary>
        [JsonProperty(PropertyName = "last_discovered", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? LastDiscovered
        {
            get => _lastDiscovered;
            set
            {
                if (value.HasValue)
                {
                    _lastDiscovered = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// MAC address, X18
        /// </summary>
        [JsonProperty(PropertyName = "mac_address", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string MacAddress { get; set; }

        /// <summary>
        /// Manufacturer original model number, X255
        /// </summary>
        [JsonProperty(PropertyName = "model_number", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ModelNumber { get; set; }

        /// <summary>
        /// Date and time the instance was last started
        /// </summary>
        [JsonProperty(PropertyName = "start_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
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
        /// Comments related to the instance, X4000
        /// </summary>
        [JsonProperty(PropertyName = "comments", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Comments { get; set; }

        /// <summary>
        /// Indicates whether the instance is monitored
        /// </summary>
        [JsonProperty(PropertyName = "monitor", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Monitor { get; set; }

        /// <summary>
        /// Primary IP address used by the instance, X255
        /// </summary>
        [JsonProperty(PropertyName = "ip_address", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string IpAddress { get; set; }

        /// <summary>
        /// Reference to cmdb_ci table
        /// </summary>
        [JsonProperty(PropertyName = "duplicate_of", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DuplicateOf { get; set; }

        /// <summary>
        /// Reference to Schedule table (for normal processing)
        /// </summary>
        [JsonProperty(PropertyName = "schedule", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Schedule { get; set; }

        /// <summary>
        /// Environment, X40
        /// </summary>
        [JsonProperty(PropertyName = "environment", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Environment { get; set; }

        /// <summary>
        /// Is instance attested, bool
        /// </summary>
        [JsonProperty(PropertyName = "attested", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Attested { get; set; }

        /// <summary>
        /// ID of the instance from another data source, X512
        /// </summary>
        [JsonProperty(PropertyName = "correlation_id", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Description of usage of attributes for the instance, X65000
        /// </summary>
        [JsonProperty(PropertyName = "attributes", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Attributes { get; set; }

        /// <summary>
        /// Name of category applicable to the instance, X40
        /// </summary>
        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Category { get; set; }

        /// <summary>
        /// Number of faults recorded against the instance to date
        /// </summary>
        [JsonProperty(PropertyName = "fault_count", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? FaultCount { get; set; }
    }
}
