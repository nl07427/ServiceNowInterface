using System;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sys_user table
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class User : Entity
    {
        /// <summary>
        /// Accumulated roles, X4000
        /// </summary>
        [JsonProperty(PropertyName = "accumulated_roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AccumulatedRoles { get; }

        /// <summary>
        /// Active
        /// </summary>
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Active { get; set; }

        /// <summary>
        /// Avatar, ServiceNow image type
        /// </summary>
        [JsonProperty(PropertyName = "avatar", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Avatar { get; set; }

        /// <summary>
        /// Building, reference to table Building
        /// </summary>
        [JsonProperty(PropertyName = "building", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Building { get; set; }

        /// <summary>
        /// Calendar integration
        /// </summary>
        [JsonProperty(PropertyName = "calendar_integration", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? CalendarIntegration { get; set; }

        /// <summary>
        /// City
        /// </summary>
        [JsonProperty(PropertyName = "city", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string City { get; set; }

        /// <summary>
        /// Reference to table Company
        /// </summary>
        [JsonProperty(PropertyName = "company", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Company { get; set; }

        /// <summary>
        /// Reference to ServiceNow 'Cost Center' table
        /// </summary>
        [JsonProperty(PropertyName = "cost_center", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CostCenter { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        [JsonProperty(PropertyName = "country", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Country { get; set; }

        /// <summary>
        /// Date format, X40
        /// </summary>
        [JsonProperty(PropertyName = "date_format", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DateFormat { get; set; }

        /// <summary>
        /// Reference to table menu list
        /// </summary>
        [JsonProperty(PropertyName = "default_perspective", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DefaultPerspective { get; set; }
        
        /// <summary>
        /// Reference to table department
        /// </summary>
        [JsonProperty(PropertyName = "department", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Department { get; set; }

        /// <summary>
        /// EDU Status, X40
        /// </summary>
        [JsonProperty(PropertyName = "edu_status", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string EduStatus { get; set; }

        /// <summary>
        /// Mail address
        /// </summary>
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Email { get; set; }
        
        /// <summary>
        /// Employee number
        /// </summary>
        [JsonProperty(PropertyName = "employee_number", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string EmployeeNumber { get; set; }

        /// <summary>
        /// Enable MFA, boolean
        /// </summary>
        [JsonProperty(PropertyName = "enable_multifactor_authn", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? EnableMultifactorAuthentication { get; set; }

        /// <summary>
        /// Count of failed login attempts
        /// </summary>
        [JsonProperty("failed_attempts", NullValueHandling = NullValueHandling.Ignore)]
        public int? FailedAttempts { get; set; }

        /// <summary>
        /// First name, X50
        /// </summary>
        [JsonProperty(PropertyName = "first_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string FirstName { get; set; }
        
        /// <summary>
        /// Gender
        /// </summary>
        [JsonProperty(PropertyName = "gender", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Gender { get; set; }

        /// <summary>
        /// Hashed user id, X200
        /// </summary>
        [JsonProperty(PropertyName = "hashed_user_id", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string HashedUserId { get;}

        /// <summary>
        /// Home phone number
        /// </summary>
        [JsonProperty(PropertyName = "home_phone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string HomePhone { get; set; }

        /// <summary>
        /// Is internal integration user, boolean
        /// </summary>
        [JsonProperty(PropertyName = "internal_integration_user", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? InternalIntegrationUser { get; set; }

        /// <summary>
        /// Name prefix
        /// </summary>
        [JsonProperty(PropertyName = "introduction", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Introduction { get; set; }

        /// <summary>
        /// Last login, date
        /// </summary>
        [JsonProperty(PropertyName = "last_login", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTime? LastLogin { get; set; }

        /// <summary>
        /// Last login device, X40
        /// </summary>
        [JsonProperty(PropertyName = "last_login_device", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LastLoginDevice { get;}

        /// <summary>
        /// Last login time
        /// </summary>
        [JsonProperty(PropertyName = "last_login_time", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// last name, X50
        /// </summary>
        [JsonProperty(PropertyName = "last_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LastName { get; set; }

        /// <summary>
        /// Last password, X40
        /// </summary>
        [JsonProperty(PropertyName = "last_password", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LastPassword { get; set; }

        /// <summary>
        /// Reference to table 'LDAP Server'
        /// </summary>
        [JsonProperty(PropertyName = "ldap_server", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink LdapServer { get; set; }

        /// <summary>
        /// Location , reference to location table
        /// </summary>
        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Location { get; set; }

        /// <summary>
        /// Is locked out
        /// </summary>
        [JsonProperty(PropertyName = "locked_out", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? LockedOut { get; set; }

        /// <summary>
        /// Manager, reference to sys_user
        /// </summary>
        [JsonProperty(PropertyName = "manager", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Manager { get; set; }

        /// <summary>
        /// Middle name, X50
        /// </summary>
        [JsonProperty(PropertyName = "middle_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string MiddleName { get; set; }

        /// <summary>
        /// Mobile phone number
        /// </summary>
        [JsonProperty(PropertyName = "mobile_phone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Display name, X151
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Notification, integer
        /// </summary>
        [JsonProperty(PropertyName = "notification", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Notification { get; set; }

        /// <summary>
        /// Password needs reset
        /// </summary>
        [JsonProperty(PropertyName = "password_needs_reset", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? PasswordNeedsReset { get; set; }

        /// <summary>
        /// Phone
        /// </summary>
        [JsonProperty(PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Phone { get; set; }

        /// <summary>
        /// Photo, ServiceNow image type
        /// </summary>
        [JsonProperty(PropertyName = "photo", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Photo { get; set; }

        /// <summary>
        /// Preferred language
        /// </summary>
        [JsonProperty(PropertyName = "preferred_language", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string PreferredLanguage { get; set; }

        /// <summary>
        /// User roles, ServiceNow 'User Roles' type, X255
        /// </summary>
        [JsonProperty(PropertyName = "roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Roles { get; set; }

        /// <summary>
        /// Schedule, reference to table Schedule
        /// </summary>
        [JsonProperty(PropertyName = "schedule", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Schedule { get; set; }

        /// <summary>
        /// Source, X255
        /// </summary>
        [JsonProperty(PropertyName = "source", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Source { get; set; }

        /// <summary>
        /// State/Province of user
        /// </summary>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string State { get; set; }

        /// <summary>
        /// Street address, X255
        /// </summary>
        [JsonProperty(PropertyName = "street", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Street { get; set; }

        /// <summary>
        /// Reference to Group (scope)
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SysDomain { get; set; }

        /// <summary>
        /// Domain path
        /// </summary>
        [JsonProperty(PropertyName = "sys_domain_path", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SysDomainPath { get; set; }

        /// <summary>
        /// Time format
        /// </summary>
        [JsonProperty(PropertyName = "time_format", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string TimeFormat { get; set; }

        /// <summary>
        /// Time zone, X40
        /// </summary>
        [JsonProperty(PropertyName = "time_zone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string TimeZone { get; set; }

        /// <summary>
        /// Title, X60
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Title { get; set; }

        /// <summary>
        /// User id
        /// </summary>
        [JsonProperty(PropertyName = "user_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string UserName { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [JsonProperty(PropertyName = "user_password", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string UserPassword { get; set; }

        /// <summary>
        /// Is VIP, boolean
        /// </summary>
        [JsonProperty(PropertyName = "vip", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Vip { get; set; }

        /// <summary>
        /// Web service access only, boolean
        /// </summary>
        [JsonProperty(PropertyName = "web_service_access_only", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? WebServiceAccessOnly { get; set; }

        /// <summary>
        /// ZIP code
        /// </summary>
        [JsonProperty(PropertyName = "zip", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Zip { get; set; }
    }
}
