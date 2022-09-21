using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// Representation of ServiceNow incident table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Incident : Task
    {
        private DateTimeOffset? _reopenedTime;
        private DateTimeOffset? _resolvedAt;

        /// <summary>
        /// Default constructor for Incident
        /// </summary>
        public Incident()
        {
            ObjectType = "incident";
        }

        /// <summary>
        ///Business impact, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "business_impact", Required = Required.Default)]
        public string BusinessImpact { get; set; }

        /// <summary>
        /// Business resolve time, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "business_stc", Required = Required.Default)]
        public int? BusinessStc { get; set; }

        /// <summary>
        /// Resolve time, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "calendar_stc", Required = Required.Default)]
        public int? CalendarStc { get; set; }

        /// <summary>
        /// Caller, sys_user reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "caller_id", Required = Required.Default)]
        public ReferenceLink CallerId { get; set; }

        /// <summary>
        ///Category, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "category", Required = Required.Default)]
        public string Category { get; set; }

        /// <summary>
        /// Probable cause, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cause", Required = Required.Default)]
        public string Cause { get; set; }

        /// <summary>
        /// Caused by Change, change_request reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "caused_by", Required = Required.Default)]
        public ReferenceLink CausedBy { get; set; }

        /// <summary>
        /// Child Incidents, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "child_incidents", Required = Required.Default)]
        public int? ChildIncidents { get; set; }

        /// <summary>
        ///Close code, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "close_code", Required = Required.Default)]
        public string CloseCode { get; set; }

        /// <summary>
        /// Contract, contract reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "contract", Required = Required.Default)]
        public ReferenceLink Contract { get; set; }

        /// <summary>
        /// Origin ID, document ID
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "origin_id", Required = Required.Default)]
        public ReferenceLink OriginId { get; set; }

        /// <summary>
        /// Origin table, X80
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "origin_table", Required = Required.Default)]
        public string OriginTable { get; set; }

        /// <summary>
        /// On hold reason, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hold_reason", Required = Required.Default)]
        public string HoldReason { get; set; }

        /// <summary>
        /// Incident state, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "incident_state", Required = Required.Default)]
        public int? IncidentState { get; set; }

        /// <summary>
        /// Notify, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "notify", Required = Required.Default)]
        public int? Notify { get; set; }

        /// <summary>
        /// Parent incident, reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent_incident", Required = Required.Default)]
        public ReferenceLink ParentIncident { get; set; }

        /// <summary>
        /// ProblemId, table problem reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "problem_id", Required = Required.Default)]
        public ReferenceLink ProblemId { get; set; }

        /// <summary>
        /// Last reopened by, table sys_user reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reopened_by", Required = Required.Default)]
        public ReferenceLink ReopenedBy { get; set; }

        /// <summary>
        /// Last reopened at, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reopened_time", Required = Required.Default)]
        public DateTimeOffset? ReopenedTime
        {
            get => _reopenedTime;
            set
            {
                if (value.HasValue)
                {
                    _reopenedTime = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Reopen count, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reopen_count", Required = Required.Default)]
        public int? ReopenCount { get; set; }

        /// <summary>
        /// Resolved, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "resolved_at", Required = Required.Default)]
        public DateTimeOffset? ResolvedAt
        {
            get => _resolvedAt;
            set
            {
                if (value.HasValue)
                {
                    _resolvedAt = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Resolved by, table sys_user reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "resolved_by", Required = Required.Default)]
        public ReferenceLink ResolvedBy { get; set; }

        /// <summary>
        /// Change Request, table change_request reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rfc", Required = Required.Default)]
        public ReferenceLink Rfc { get; set; }

        /// <summary>
        /// Severity, integer
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "severity", Required = Required.Default)]
        public int? Severity { get; set; }

        /// <summary>
        /// Subcategory, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subcategory", Required = Required.Default)]
        public string SubCategory { get; set; }

        /// <summary>
        /// Splunk URL, X1000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "x_splu2_splunk_ser_splunk_url", Required = Required.Default)]
        public string SplunkURL { get; set; }
    }
}
