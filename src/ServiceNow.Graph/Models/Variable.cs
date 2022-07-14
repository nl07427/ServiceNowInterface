using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow Variable table (item_option_new)
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class Variable : Question
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Variable()
        {
            ObjectType = "item_option_new";
        }

        /// <summary>
        /// Variable category reference
        /// </summary>
        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Category { get; set; }

        /// <summary>
        /// Reference to catalog item
        /// </summary>
        [JsonProperty(PropertyName = "cat_item", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CatalogItem { get; set; }

        /// <summary>
        /// Reference to the execution plan
        /// </summary>
        [JsonProperty(PropertyName = "delivery_plan", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DeliveryPlan { get; set; }

        /// <summary>
        /// Description, ServiceNow type 'HTML', X8000
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Global
        /// </summary>
        [JsonProperty(PropertyName = "global", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Global { get; set; }

        /// <summary>
        /// Instructions, ServiceNow 'Translated HTML' type, X65536
        /// </summary>
        [JsonProperty(PropertyName = "instructions", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Instructions { get; set; }

        /// <summary>
        /// Widget, reference to table sp_widget
        /// </summary>
        [JsonProperty(PropertyName = "sp_widget", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Widget { get; set; }

        /// <summary>
        /// Validation regex
        /// </summary>
        [JsonProperty(PropertyName = "validate_regex", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ValidateRegex { get; set; }

        /// <summary>
        /// Reference to the variable set table
        /// </summary>
        [JsonProperty(PropertyName = "variable_set", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink VariableSet { get; set; }

        /// <summary>
        /// Variable width, X40
        /// </summary>
        [JsonProperty(PropertyName = "variable_width", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string VariableWidth { get; set; }

        /// <summary>
        /// Visibility, X40
        /// </summary>
        [JsonProperty(PropertyName = "visibility", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Visibility { get; set; }

        /// <summary>
        /// Visible on bundles
        /// </summary>
        [JsonProperty(PropertyName = "visible_bundle", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? VisibleBundle { get; set; }

        /// <summary>
        /// Visible on guides
        /// </summary>
        [JsonProperty(PropertyName = "visible_guide", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? VisibleGuide { get; set; }

        /// <summary>
        /// Visible elsewhere
        /// </summary>
        [JsonProperty(PropertyName = "visible_standalone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? VisibleStandalone { get; set; }

        /// <summary>
        /// Visible on summaries
        /// </summary>
        [JsonProperty(PropertyName = "visible_summary", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? VisibleSummary { get; set; }

        /// <summary>
        /// Enable also request for, Bool
        /// </summary>
        [JsonProperty(PropertyName = "enable_also_request_for", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? EnableAlsoRequestFor
        {
            get; set;
        }

        /// <summary>
        /// Hidden, Bool
        /// </summary>
        [JsonProperty(PropertyName = "hidden", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Hidden
        {
            get; set;
        }

        /// <summary>
        /// Macroponent, reference to UX Macroponent definition
        /// </summary>
        [JsonProperty(PropertyName = "macroponent", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Macroponent
        {
            get; set;
        }

        /// <summary>
        /// Published option, reference to self (item_option_new)
        /// </summary>
        [JsonProperty(PropertyName = "published_ref", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink PublishedOption
        {
            get; set;
        }

        /// <summary>
        /// Rich text, Translated HTML (Text field)
        /// </summary>
        [JsonProperty(PropertyName = "rich_text", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RichText
        {
            get; set;
        }

        /// <summary>
        /// Save script, Script plain (X8000)
        /// </summary>
        [JsonProperty(PropertyName = "save_script", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string SaveScript
        {
            get; set;
        }

        /// <summary>
        ///	Roles to use also request for, X255
        /// </summary>
        [JsonProperty(PropertyName = "roles_to_use_also_request_for", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RolesToUseAlsoRequestFor
        {
            get; set;
        }
        /// <summary>
        ///	Is unique, Bool
        /// </summary>
        [JsonProperty(PropertyName = "unique", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Unique
        {
            get; set;
        }
    }
}
