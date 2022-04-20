using System;
using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow BaseConfigurationItem (cmdb) entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class BaseConfigurationItem : Entity
    {
        private DateTimeOffset? _checkedIn;
        private DateTimeOffset? _installDate;
        private DateTimeOffset? _warrantExpirationDate;
        private DateTimeOffset? _checkedOut;
        private DateTimeOffset? _orderDate;
        private DateTimeOffset? _deliveryDate;
        private DateTimeOffset? _dueDate;
        private DateTimeOffset? _assigned;
        private DateTimeOffset? _purchaseDate;

        /// <summary>
        /// Default constructor
        /// </summary>
        protected internal BaseConfigurationItem()
        {
        }

        /// <summary>
        /// ID of the domain to which the instance belongs
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SysDomain { get; set; }

            /// <summary>
            /// Skip sync, boolean and read-only
            /// </summary>
            [JsonProperty(PropertyName = "skip_sync", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? SkipSync { get;}

        /// <summary>
        /// Reference to sys_user_group
        /// </summary>
        [JsonProperty(PropertyName = "assignment_group", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink AssignmentGroup { get; set; }

        /// <summary>
        /// Reference to sys_user
        /// </summary>
        [JsonProperty(PropertyName = "managed_by", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ManagedBy { get; set; }

        /// <summary>
        /// Reference to core_company
        /// </summary>
        [JsonProperty(PropertyName = "manufacturer", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Manufacturer { get; set; }

        /// <summary>
        /// Purchase order number used in acquisition process, X40
        /// </summary>
        [JsonProperty(PropertyName = "po_number", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string PoNumber { get; set; }

        /// <summary>
        ///  Description of the manner of which the instance was due , X40
        /// </summary>
        [JsonProperty(PropertyName = "due_in", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DueIn { get; set; }

        /// <summary>
        /// Date and time of checking in
        /// </summary>
        [JsonProperty(PropertyName = "checked_in", NullValueHandling = NullValueHandling.Ignore,
            Required = Required.Default)]
        public DateTimeOffset? CheckedIn
        {
            get => _checkedIn;
            set
            {
                if (value.HasValue)
                {
                    _checkedIn = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// System Class path, X255
        /// </summary>
        [JsonProperty(PropertyName = "sys_class_path", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SysClassPath { get; }

        /// <summary>
        /// Reference to core_company
        /// </summary>
        [JsonProperty(PropertyName = "vendor", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Vendor { get; set; }

        /// <summary>
        /// Reference to core_company
        /// </summary>
        [JsonProperty(PropertyName = "company", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Company { get; set; }

        /// <summary>
        /// Date and time instance was most recently installed
        /// </summary>
        [JsonProperty(PropertyName = "install_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? InstallDate
        {
            get => _installDate;
            set
            {
                if (value.HasValue)
                {
                    _installDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Description of the justification for the instance, X80
        /// </summary>
        [JsonProperty(PropertyName = "justification", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Justification { get; set; }

        /// <summary>
        /// Reference to cmn_department
        /// </summary>
        [JsonProperty(PropertyName = "department", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Department { get; set; }

        /// <summary>
        /// General Ledger account name/number, X40
        /// </summary>
        [JsonProperty(PropertyName = "gl_account", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string GlAccount { get; set; }

        /// <summary>
        /// Invoice number used in acquisition process
        /// </summary>
        [JsonProperty(PropertyName = "invoice_number", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// Reference to sys_user table
        /// </summary>
        [JsonProperty(PropertyName = "assigned_to", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink AssignedTo { get; set; }

        /// <summary>
        /// Date current warranty expires
        /// </summary>
        [JsonProperty(PropertyName = "warranty_expiration", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? WarrantyExpiration
        {
            get => _warrantExpirationDate;
            set
            {
                if (value.HasValue)
                {
                    _warrantExpirationDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Asset tag/service tag for the specific asset, X40
        /// </summary>
        [JsonProperty(PropertyName = "asset_tag", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AssetTag { get; set; }

        /// <summary>
        /// Financial value in local currency (as defined in the Cost Currency field), X40
        /// </summary>
        [JsonProperty(PropertyName = "cost", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Cost { get; set; }

        /// <summary>
        /// Reference to sys_user
        /// </summary>
        [JsonProperty(PropertyName = "owned_by", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink OwnedBy { get; set; }

        /// <summary>
        /// Serial number of the instance, X255
        /// </summary>
        [JsonProperty(PropertyName = "serial_number", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SerialNumber { get; set; }

        /// <summary>
        /// Date and time of checking out
        /// </summary>
        [JsonProperty(PropertyName = "checked_out", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? CheckedOut
        {
            get => _checkedOut;
            set
            {
                if (value.HasValue)
                {
                    _checkedOut = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Reference to Product Model table
        /// </summary>
        [JsonProperty(PropertyName = "model_id", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ModelId { get; set; }

        /// <summary>
        /// Path of the domain to which the instance belongs, X255
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain_path", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SysDomainPath { get; set; }

        /// <summary>
        /// Name of currency (such as dollars, pounds, Euros), X3
        /// </summary>
        [JsonProperty(PropertyName = "cost_cc", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string CostCc { get; set; }

        /// <summary>
        /// Date and time instance was initially ordered
        /// </summary>
        [JsonProperty(PropertyName = "order_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? OrderDate
        {
            get => _orderDate;
            set
            {
                if (value.HasValue)
                {
                    _orderDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Reference to sys_user_group
        /// </summary>
        [JsonProperty(PropertyName = "support_group", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SupportGroup { get; set; }

        /// <summary>
        /// Date and time instance was initially received
        /// </summary>
        [JsonProperty(PropertyName = "delivery_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? DeliveryDate
        {
            get => _deliveryDate;
            set
            {
                if (value.HasValue)
                {
                    _deliveryDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        ///  Configurable choice list with values for current functional states
        /// </summary>
        [JsonProperty(PropertyName = "install_status", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? InstallStatus { get; set; }

        /// <summary>
        /// Reference to cmn_costcenter
        /// </summary>
        [JsonProperty(PropertyName = "cost_center", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CostCenter { get; set; }

        /// <summary>
        /// Date and time instance was due
        /// </summary>
        [JsonProperty(PropertyName = "due", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? Due
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
        /// Reference to sys_user table
        /// </summary>
        [JsonProperty(PropertyName = "supported_by", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SupportedBy { get; set; }

        /// <summary>
        /// Name of the CI instance, X255
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        /// Flag indicating whether verification is required for the instance
        /// </summary>
        [JsonProperty(PropertyName = "unverified", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Unverified { get; set; }

        /// <summary>
        /// Date and time of assignment to user
        /// </summary>
        [JsonProperty(PropertyName = "assigned", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? Assigned
        {
            get => _assigned;
            set
            {
                if (value.HasValue)
                {
                    _assigned = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Reference to cmn_location table
        /// </summary>
        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Location { get; set; }

        /// <summary>
        /// Reference to Asset table
        /// </summary>
        [JsonProperty(PropertyName = "asset", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Asset { get; set; }

        /// <summary>
        /// Date instance was purchased
        /// </summary>
        [JsonProperty(PropertyName = "purchase_date", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTimeOffset? PurchaseDate
        {
            get => _purchaseDate;
            set
            {
                if (value.HasValue)
                {
                    _purchaseDate = value.Value + value.Value.Offset;
                }
            }
        }

        /// <summary>
        /// Number of current leasing contracts, X40
        /// </summary>
        [JsonProperty(PropertyName = "lease_id", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LeaseId { get; set; }
    }
}
