using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow Question entity
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Question : ApplicationFile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        protected internal Question()
        {
        }

        /// <summary>
        /// Lookup label field(s), X80
        /// </summary>
        [JsonProperty(PropertyName = "lookup_label", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LookupLabel { get; set; }

        /// <summary>
        /// Dynamic reference qualifiers (reference table Dynamic Filter Options)
        /// </summary>
        [JsonProperty(PropertyName = "dynamic_ref_qual", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DynamicRefQual { get; set; }

        /// <summary>
        /// Lookup recurring price field, X80
        /// </summary>
        [JsonProperty(PropertyName = "rec_lookup_price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RecLookupPrice { get; set; }

        /// <summary>
        /// Recurring price if checked, X20
        /// </summary>
        [JsonProperty(PropertyName = "rec_price_if_checked", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RecPriceIfChecked { get; set; }

        /// <summary>
        /// Choice field, X80
        /// </summary>
        [JsonProperty(PropertyName = "choice_field", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ChoiceField { get; set; }

        /// <summary>
        /// Display the title?
        /// </summary>
        [JsonProperty(PropertyName = "display_title", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? DisplayTitle { get; set; }

        /// <summary>
        /// Tooltip, ServiceNow translated type field, X40
        /// </summary>
        [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
        public string Tooltip { get; set; }

        /// <summary>
        /// Always expanded, boolean
        /// </summary>
        [JsonProperty(PropertyName = "show_help_on_load", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? ShowHelpOnLoad { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Type { get; set; }

        /// <summary>
        /// UI Page, reference to table 'UI Page'
        /// </summary>
        [JsonProperty(PropertyName = "ui_page", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink UiPage { get; set; }

        /// <summary>
        /// Reference, ServiceNow type 'Table name', X80
        /// </summary>
        [JsonProperty(PropertyName = "reference", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Reference { get; set; }

        /// <summary>
        /// Lookup from table, ServiceNow type 'Table name', X80
        /// </summary>
        [JsonProperty(PropertyName = "lookup_table", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LookupTable { get; set; }

        /// <summary>
        /// Lookup value field, ServiceNow 'Field name' type, X80
        /// </summary>
        [JsonProperty(PropertyName = "lookup_value", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LookupValue { get; set; }

        /// <summary>
        /// Record, X40
        /// </summary>
        [JsonProperty(PropertyName = "record", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Record { get; set; }

        /// <summary>
        /// Use confirmation, boolean
        /// </summary>
        [JsonProperty(PropertyName = "mask_use_confirmation", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? MaskUseConfirmation { get; set; }

        /// <summary>
        /// Reference qualifier conditions, ServiceNow type 'Conditions', X4000
        /// </summary>
        [JsonProperty("reference_qual_condition", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink ReferenceQualCondition { get; set; }

        /// <summary>
        /// Sort order
        /// </summary>
        [JsonProperty(PropertyName = "order", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public long? Order { get; set; }

        /// <summary>
        /// Map to field
        /// </summary>
        [JsonProperty(PropertyName = "map_to_field", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? MapToField { get; set; }

        /// <summary>
        /// Choice direction, X40
        /// </summary>
        [JsonProperty(PropertyName = "choice_direction", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ChoiceDirection { get; set; }

        /// <summary>
        /// Delete Roles, ServiceNow type 'User Roles', X255
        /// </summary>
        [JsonProperty(PropertyName = "delete_roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DeleteRoles { get; set; }

        /// <summary>
        /// Active, boolean
        /// </summary>
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Active { get; set; }

        /// <summary>
        /// Choice table, X80
        /// </summary>
        [JsonProperty(PropertyName = "choice_table", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ChoiceTable { get; set; }

        /// <summary>
        /// Field, ServiceNow type 'Field name'
        /// </summary>
        [JsonProperty(PropertyName = "field", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Field { get; set; }

        /// <summary>
        /// Variable name, X100
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Help text, ServiceNow type 'Translated text', X4000
        /// </summary>
        [JsonProperty(PropertyName = "help_text", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string HelpText { get; set; }

        /// <summary>
        /// Use dynamic default
        /// </summary>
        [JsonProperty(PropertyName = "use_dynamic_default", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? UseDynamicDefault { get; set; }

        /// <summary>
        /// Scale min
        /// </summary>
        [JsonProperty(PropertyName = "scale_min", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ScaleMin { get; set; }

        /// <summary>
        /// Show Help
        /// </summary>
        [JsonProperty(PropertyName = "show_help", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? ShowHelp { get; set; }

        /// <summary>
        /// mandatory, boolean
        /// </summary>
        [JsonProperty(PropertyName = "mandatory", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Mandatory { get; set; }

        /// <summary>
        /// Do not select the first choice
        /// </summary>
        [JsonProperty(PropertyName = "do_not_select_first", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? DoNotSelectFirst { get; set; }

        /// <summary>
        /// Dynamic default value, reference to 'Dynamic Filter Options'
        /// </summary>
        [JsonProperty(PropertyName = "dynamic_default_value", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DynamicDefaultValue { get; set; }

        /// <summary>
        /// Example text, ServiceNow translated field type, X255
        /// </summary>
        [JsonProperty(PropertyName = "example_text", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ExampleText { get; set; }

        /// <summary>
        /// Write Roles, ServiceNow type 'User Roles', X255
        /// </summary>
        [JsonProperty(PropertyName = "write_roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string WriteRoles { get; set; }

        /// <summary>
        /// Pricing  implications, boolean
        /// </summary>
        [JsonProperty(PropertyName = "pricing_implications", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? PricingImplications { get; set; }

        /// <summary>
        /// Read Roles, ServiceNow type 'User Roles', X255
        /// </summary>
        [JsonProperty(PropertyName = "read_roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ReadRoles { get; set; }

        /// <summary>
        /// variable name, X80
        /// </summary>
        [JsonProperty(PropertyName = "variable_name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string VariableName { get; set; }

        /// <summary>
        /// Create Roles, ServiceNow type 'User Roles', X255
        /// </summary>
        [JsonProperty(PropertyName = "create_roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string CreateRoles { get; set; }

        /// <summary>
        /// List table, ServiceNow type 'Table name', X80
        /// </summary>
        [JsonProperty(PropertyName = "list_table", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ListTable { get; set; }

        /// <summary>
        /// Table, ServiceNow 'Table name' field type, X80
        /// </summary>
        [JsonProperty(PropertyName = "table", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Table { get; set; }

        /// <summary>
        /// Macro, reference to Macro table
        /// </summary>
        [JsonProperty(PropertyName = "macro", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Macro { get; set; }

        /// <summary>
        /// Use reference qualifier, X40
        /// </summary>
        [JsonProperty(PropertyName = "use_reference_qualifier", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string UseReferenceQualifier { get; set; }

        /// <summary>
        /// Use encryption, boolean
        /// </summary>
        [JsonProperty(PropertyName = "mask_use_encryption", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? MaskUseEncryption { get; set; }

        /// <summary>
        /// Include none, boolean
        /// </summary>
        [JsonProperty(PropertyName = "include_none", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? IncludeNone { get; set; }

        /// <summary>
        /// Lookup price, ServiceNow 'Field Name' type, X80
        /// </summary>
        [JsonProperty(PropertyName = "lookup_price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string LookupPrice { get; set; }

        /// <summary>
        /// Default value, X512
        /// </summary>
        [JsonProperty(PropertyName = "default_value", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Price if checked, ServiceNow Price field type
        /// </summary>
        [JsonProperty(PropertyName = "price_if_checked", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string PriceIfChecked { get; set; }

        /// <summary>
        /// Help tag,  ServiceNow 'Translated' field type, X40
        /// </summary>
        [JsonProperty(PropertyName = "help_tag", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string HelpTag { get; set; }

        /// <summary>
        /// Layout, X40
        /// </summary>
        [JsonProperty(PropertyName = "layout", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Layout { get; set; }

        /// <summary>
        /// Question, ServiceNow 'Translated' field type, X255
        /// </summary>
        [JsonProperty(PropertyName = "question_text", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string QuestionText { get; set; }

        /// <summary>
        /// Summary macro, reference to macro table
        /// </summary>
        [JsonProperty(PropertyName = "summary_macro", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink SummaryMacro { get; set; }

        /// <summary>
        /// Record producer table, X80
        /// </summary>
        [JsonProperty(PropertyName = "record_producer_table", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RecordProducerTable { get; set; }

        /// <summary>
        /// Scale max, X40
        /// </summary>
        [JsonProperty(PropertyName = "scale_max", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ScaleMax { get; set; }

        /// <summary>
        /// Variable attributes, X255
        /// </summary>
        [JsonProperty(PropertyName = "attributes", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Attributes { get; set; }

        /// <summary>
        /// Unique values only
        /// </summary>
        [JsonProperty(PropertyName = "lookup_unique", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? LookupUnique { get; set; }

        /// <summary>
        /// Reference qualifier, X4000
        /// </summary>
        [JsonProperty(PropertyName = "reference_qual", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ReferenceQual { get; set; }

        /// <summary>
        /// Default HTML, X65536
        /// </summary>
        [JsonProperty(PropertyName = "default_html_value", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DefaultHtmlValue { get; set; }
    }
}
