using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    /// <summary>
    /// Extensions of the ServiceNow incident table.
    /// </summary>
    public partial class Incident
    {
        private DateTimeOffset? _lastFollowUp;
        private DateTimeOffset? _actualStartDate;
        private DateTimeOffset? _startDate;

        /// <summary>
        /// CyberSecurity details, X1000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_cybersecurity_details", Required = Required.Default)]
        public string CyberSecurityDetails { get; set; }

        /// <summary>
        /// External Reference, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_external_reference", Required = Required.Default)]
        public string ExternalReference { get; set; }

        /// <summary>
        /// Follow Up History, X1000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_follow_up_history", Required = Required.Default)]
        public string FollowUpHistory { get; set; }

        /// <summary>
        /// Last Follow Up date, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_last_followup_date", Required = Required.Default)]
        public DateTimeOffset? LastFollowUpDate
        {
            get => _lastFollowUp;
            set
            {
                if (value.HasValue)
                {
                    _lastFollowUp = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Number of Follow Up, long
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_number_of_follow_up", Required = Required.Default)]
        public long? FollowUpCount { get; set; }

        /// <summary>
        ///Number of Wrong Escalation, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_number_of_wrong_escalation", Required = Required.Default)]
        public string WrongEscalationCount { get; set; }

        /// <summary>
        /// Previous Assignment Group, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_previous_group", Required = Required.Default)]
        public string PreviousAssignmentGroup { get; set; }

        /// <summary>
        /// Proven Incident, bool
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_proven_incident", Required = Required.Default)]
        public bool? ProvenIncident { get; set; }

        /// <summary>
        /// Real Start Date, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_real_start_date", Required = Required.Default)]
        public DateTimeOffset? ActualStartDate
        {
            get => _actualStartDate;
            set
            {
                if (value.HasValue)
                {
                    _actualStartDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Security Impact, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_security_impact", Required = Required.Default)]
        public string SecurityImpact{ get; set; }

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
        /// Send to Claranet, bool
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_send_to_claranet", Required = Required.Default)]
        public bool? SendToClaranet { get; set; }

        /// <summary>
        /// Source, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_source", Required = Required.Default)]
        public string Source { get; set; }

        /// <summary>
        /// On hold Time, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_unsuspend_time", Required = Required.Default)]
        public string OnHoldTime { get; set; }

        /// <summary>
        /// User C.I, asset reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_user_c_i", Required = Required.Default)]
        public ReferenceLink UserCi { get; set; }

        /// <summary>
        ///Wrong Escalation History, X1000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_wrong_escalation_history", Required = Required.Default)]
        public string WrongEscalationHistory { get; set; }
    }
}
