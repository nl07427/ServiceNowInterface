using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models.Extensions
{
    /// <summary>
    /// Extensions of the ServiceNow sc_task table.
    /// </summary>
    public partial class CatalogTask
    {
        private DateTimeOffset? _lastFollowUp;
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
        public DateTimeOffset? LastFollowUp
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
        /// Number of Follow Up, X15
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_number_of_follow_up", Required = Required.Default)]
        public string FollowUpCount { get; set; }

        /// <summary>
        /// Number of Wrong Escalation, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_number_of_wrong_escalation", Required = Required.Default)]
        public string WrongEscalationCount { get; set; }

        /// <summary>
        /// Previous assignment Group, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_previous_group", Required = Required.Default)]
        public string PreviousAssignmentGroup { get; set; }

        /// <summary>
        /// Send To Claranet, boolean
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_send_to_claranet", Required = Required.Default)]
        public bool? IsSendToClaranet { get; set; }

        /// <summary>
        /// Unit of work, X15
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_unit_of_work", Required = Required.Default)]
        public string UnitOfWork { get; set; }

        /// <summary>
        /// Wrong Escalation History, X1000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "u_wrong_escalation_history", Required = Required.Default)]
        public string WrongEscalationHistory { get; set; }
    }
}
