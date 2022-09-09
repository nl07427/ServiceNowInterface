using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Models.Helpers;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow Task entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class Task : Entity
    {
        private DateTimeOffset? _closedAt;
        private DateTimeOffset? _expectedStart;
        private DateTimeOffset? _openedAt;
        private DateTimeOffset? _workEnd;
        private DateTimeOffset? _approvalSet;
        private DateTimeOffset? _workStart;
        private DateTimeOffset? _followUp;
        private DateTimeOffset? _activityDue;
        private DateTimeOffset? _slaDue;
        private DateTimeOffset? _dueDate;

        /// <summary>
        /// Default constructor
        /// </summary>
        protected internal Task()
        {
        }

        /// <summary>
        /// The parent task record referenced by this catalog task
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "parent", Required = Required.Default)]
        public ReferenceLink Parent { get; set; }

        /// <summary>
        /// SLA requirements met, boolean
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "made_sla", Required = Required.Default)]
        public bool? MadeSla { get; set; }

        /// <summary>
        /// Watch list, reference to table User
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "watch_list", Required = Required.Default)]
        public string WatchList { get; set; }

        /// <summary>
        /// Action to take if task is rejected (X40, default value is cancel)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "upon_reject", Required = Required.Default)]
        public string UponReject { get; set; }

        /// <summary>
        /// Reference to table Journal (X4000)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "approval_history", Required = Required.Default)]
        public string ApprovalHistory { get; set; }

        /// <summary>
        /// The generated task number
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "number", Required = Required.Default)]
        public string Number { get; set; }

        /// <summary>
        /// Reference to user that opened/created the task
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "opened_by", Required = Required.Default)]
        public ReferenceLink OpenedBy { get; set; }

        /// <summary>
        /// user input (X4000)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "user_input", Required = Required.Default)]
        public string UserInput { get; set; }

        /// <summary>
        /// ServiceNow domain, reference to table sys_user_group
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_domain", Required = Required.Default)]
        public ReferenceLink SysDomain { get; set; }

        /// <summary>
        /// Task state, integer (N1)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "state", Required = Required.Default)]
        public Int32? State { get; set; }

        /// <summary>
        /// Knowledge entry, boolean
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "knowledge", Required = Required.Default)]
        public bool? Knowledge { get; set; }

        /// <summary>
        /// Order
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "order", Required = Required.Default)]
        public string Order { get; set; }

        /// <summary>
        /// DateTime task was closed
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "closed_at", Required = Required.Default)]
        public DateTimeOffset? ClosedAt
        {
            get => _closedAt;
            set
            {
                if (value.HasValue)
                {
                    _closedAt = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Reference to table configuration item
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "cmdb_ci", Required = Required.Default)]
        public ReferenceLink CmdbCi { get; set; }

        /// <summary>
        /// Reference to table execution plan
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "delivery_plan", Required = Required.Default)]
        public ReferenceLink DeliveryPlan { get; set; }

        /// <summary>
        /// Impact of task (integer, default value = 3)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "impact", Required = Required.Default)]
        public Int32? Impact { get; set; }

        /// <summary>
        /// Active state of task, boolean
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "active", Required = Required.Default)]
        public bool? Active { get; set; }

        /// <summary>
        /// List, reference to table user
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "work_notes_list", Required = Required.Default)]
        public string WorkNotesList { get; set; }

        /// <summary>
        /// Reference to business service
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "business_service", Required = Required.Default)]
        public ReferenceLink BusinessService { get; set; }

        /// <summary>
        /// Task priority
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "priority", Required = Required.Default)]
        public Int32? Priority { get; set; }

        /// <summary>
        /// Domain path (X255)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sys_domain_path", Required = Required.Default)]
        public string SysDomainPath { get; set; }

        /// <summary>
        /// ServiceNow timer type, elapsed time
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "time_worked", Required = Required.Default)]
        public string TimeWorked { get; set; }

        /// <summary>
        /// Expected start, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "expected_start", Required = Required.Default)]
        public DateTimeOffset? ExpectedStart
        {
            get => _expectedStart;
            set
            {
                if (value.HasValue)
                {
                    _expectedStart = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Opened at, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "opened_at", Required = Required.Default)]
        public DateTimeOffset? OpenedAt
        {
            get => _openedAt;
            set
            {
                if (value.HasValue)
                {
                    _openedAt = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// ServiceNow duration type, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "business_duration", Required = Required.Default)]
        public SnowDuration BusinessDuration { get; set; }

        /// <summary>
        /// Reference to the assignment groups of the task
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "group_list", Required = Required.Default)]
        public string GroupList { get; set; }

        /// <summary>
        /// Actual end, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "work_end", Required = Required.Default)]
        public DateTimeOffset? WorkEnd
        {
            get => _workEnd;
            set
            {
                if (value.HasValue)
                {
                    _workEnd = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Approval set, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "approval_set", Required = Required.Default)]
        public DateTimeOffset? ApprovalSet
        {
            get => _approvalSet;
            set
            {
                if (value.HasValue)
                {
                    _approvalSet = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Reference to table journal input (X4000)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "work_notes", Required = Required.Default)]
        public string WorkNotes { get; set; }

        /// <summary>
        /// Short description, X160
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "short_description", Required = Required.Default)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Correlation display
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "correlation_display", Required = Required.Default)]
        public string CorrelationDisplay { get; set; }

        /// <summary>
        /// Reference to table Execution Plan Task
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "delivery_task", Required = Required.Default)]
        public ReferenceLink DeliveryTask { get; set; }

        /// <summary>
        /// Actual start of fulfillment, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "work_start", Required = Required.Default)]
        public DateTimeOffset? WorkStart
        {
            get => _workStart;
            set
            {
                if (value.HasValue)
                {
                    _workStart = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Assignment group reference
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "assignment_group", Required = Required.Default)]
        public ReferenceLink AssignmentGroup { get; set; }

        /// <summary>
        /// Reference list to additional assignee's (table User)
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "additional_assignee_list", Required = Required.Default)]
        public string AdditionalAssigneeList { get; set; }

        /// <summary>
        /// Long description, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description", Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Duration, ServiceNow type Duration (extension of datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "calendar_duration", Required = Required.Default)]
        public SnowDuration CalendarDuration
        {
            get;
            set;
        }

        /// <summary>
        /// Close note, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "close_notes", Required = Required.Default)]
        public string CloseNotes { get; set; }

        /// <summary>
        /// Service offering, reference to table 'Service Offering'
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "service_offering", Required = Required.Default)]
        public ReferenceLink ServiceOffering { get; set; }

        /// <summary>
        /// Closed by user, reference to User table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "closed_by", Required = Required.Default)]
        public ReferenceLink ClosedBy { get; set; }

        /// <summary>
        /// Follow up, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "follow_up", Required = Required.Default)]
        public DateTimeOffset? FollowUp
        {
            get => _followUp;
            set
            {
                if (value.HasValue)
                {
                    _followUp = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Contact type
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "contact_type", Required = Required.Default)]
        public string ContactType { get; set; }

        /// <summary>
        /// Urgency, integer, default value is 3
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "urgency", Required = Required.Default)]
        public Int32? Urgency { get; set; }

        /// <summary>
        /// Company, reference to company table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "company", Required = Required.Default)]
        public ReferenceLink Company { get; set; }

        /// <summary>
        /// Reassignment count, integer
        /// </summary>
        [JsonProperty(PropertyName = "reassignment_count", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public Int32? ReassignmentCount { get; set; }

        /// <summary>
        /// Activity due, ServiceNow type 'Due date'
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "activity_due", Required = Required.Default)]
        public DateTimeOffset? ActivityDue
        {
            get => _activityDue;
            set
            {
                if (value.HasValue)
                {
                    _activityDue = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Assigned to, reference to user table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "assigned_to", Required = Required.Default)]
        public ReferenceLink AssignedTo { get; set; }

        /// <summary>
        /// Additional comments, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "comments", Required = Required.Default)]
        public string Comments { get; set; }

        /// <summary>
        /// Approval, default value is 'not requested', X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "approval", Required = Required.Default)]
        public string Approval { get; set; }

        /// <summary>
        ///  Due date (date) based on service level agreement
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sla_due", Required = Required.Default)]
        public DateTimeOffset? SlaDue
        {
            get => _slaDue;
            set
            {
                if (value.HasValue)
                {
                    _slaDue = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// ServiceNow journal list type, X4000
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "comments_and_work_notes", Required = Required.Default)]
        public string CommentsAndWorkNotes { get; set;}

        /// <summary>
        /// Due date, datetime
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "due_date", Required = Required.Default)]
        public DateTimeOffset? DueDate
        {
            get => _dueDate;
            set
            {
                if (value.HasValue)
                {
                    _dueDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Escalation state, integer, default value is 0
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "escalation", Required = Required.Default)]
        public Int32? Escalation { get; set; }

        /// <summary>
        /// Upon approval state, defaul value is 'proceed'
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "upon_approval", Required = Required.Default)]
        public string UponApproval { get; set; }

        /// <summary>
        /// Correlation id, X100
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "correlation_id", Required = Required.Default)]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Variables, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "variables", Required = Required.Default)]
        public string Variables { get; set; }

        /// <summary>
        /// Rejection go to task, reference to task table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "rejection_goto", Required = Required.Default)]
        public ReferenceLink RejectionGoto { get; set; }

        /// <summary>
        /// Reference to location table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "location", Required = Required.Default)]
        public ReferenceLink Location { get; set; }

        /// <summary>
        /// Reference to wf_activity table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "wf_activity", Required = Required.Default)]
        public ReferenceLink WorkflowActivity { get; set; }

        /// <summary>
        /// Universal request, reference to Task table
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "universal_request", Required = Required.Default)]
        public ReferenceLink UniversalRequest
        { get; set; }

        /// <summary>
        /// Request state, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "request_state", Required = Required.Default)]
        public string RequestState
        {
            get; set;
        }

        /// <summary>
        /// Transfer reason, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "route_reason", Required = Required.Default)]
        public string RouteReason
        {
            get; set;
        }

        /// <summary>
        /// Effective number, X40
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "task_effective_number", Required = Required.Default)]
        public string TaskEffectiveNumber
        {
            get; set;
        }

    }
}
