using Newtonsoft.Json;
using ServiceNow.Graph.Models.Helpers;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sc_cat_item
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CatalogItem : ApplicationFile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public CatalogItem()
        {
            ObjectType = "sc_cat_item";
        }

        /// <summary>
        /// Access type, X40
        /// </summary>
        [JsonProperty(PropertyName = "access_type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string AccessType { get; set; }

        /// <summary>
        /// Active, bool
        /// </summary>
        [JsonProperty(PropertyName = "active", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Active { get; set; }

        /// <summary>
        /// Availability, X40
        /// </summary>
        [JsonProperty(PropertyName = "availability", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Availability { get; set; }

        /// <summary>
        /// Billable, true
        /// </summary>
        [JsonProperty(PropertyName = "billable", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? Billable { get; set; }

        /// <summary>
        /// Category, sc_category reference
        /// </summary>
        [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Category { get; set; }

        /// <summary>
        /// Checked out, X40
        /// </summary>
        [JsonProperty(PropertyName = "checked_out", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string CheckedOut { get; set; }

        /// <summary>
        /// Cost, X15
        /// </summary>
        [JsonProperty(PropertyName = "cost", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Cost { get; set; }

        /// <summary>
        /// Cart, reference to macro
        /// </summary>
        [JsonProperty(PropertyName = "custom_cart", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink CustomCart { get; set; }

        /// <summary>
        /// Execution Plan, reference
        /// </summary>
        [JsonProperty(PropertyName = "delivery_plan", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink DeliveryPlan { get; set; }

        /// <summary>
        /// Delivery plan script, X4000
        /// </summary>
        [JsonProperty(PropertyName = "delivery_plan_script", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DeliveryPlanScript { get; set; }

        /// <summary>
        /// Delivery time, X40, Duration, example value 2 00:00:00
        /// </summary>
        [JsonProperty(PropertyName = "delivery_time", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public SnowDuration DeliveryTime {get; set; }

        /// <summary>
        /// Description, X8000
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Display price property, X40
        /// </summary>
        [JsonProperty(PropertyName = "display_price_property", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DisplayPriceProperty { get; set; }

        /// <summary>
        /// Entitlement script, X4000
        /// </summary>
        [JsonProperty(PropertyName = "entitlement_script", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string EntitlementScript { get; set; }

        /// <summary>
        /// Flow, X32 reference
        /// </summary>
        [JsonProperty(PropertyName = "flow_designer_flow", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink FlowDesignerFlow { get; set; }

        /// <summary>
        /// Fulfillment automation level, X40
        /// </summary>
        [JsonProperty(PropertyName = "fulfillment_automation_level", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string FulfillmentAutomationLevel
        { get; set; }

        /// <summary>
        /// Fulfillment group, sys_user_group reference
        /// </summary>
        [JsonProperty(PropertyName = "group", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Group { get; set; }

        /// <summary>
        /// Hide on Service Portal, bool
        /// </summary>
        [JsonProperty(PropertyName = "hide_sp", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? HideSp { get; set; }

        /// <summary>
        /// Icon, X40
        /// </summary>
        [JsonProperty(PropertyName = "icon", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Icon { get; set; }

        /// <summary>
        /// Ignore price, bool
        /// </summary>
        [JsonProperty(PropertyName = "ignore_price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? IgnorePrice { get; set; }

        /// <summary>
        /// Basic Image, X40
        /// </summary>
        [JsonProperty(PropertyName = "image", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Image { get; set; }

        /// <summary>
        /// List Price, X20
        /// </summary>
        [JsonProperty(PropertyName = "list_price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ListPrice { get; set; }

        /// <summary>
        /// Location, cmn_location reference
        /// </summary>
        [JsonProperty(PropertyName = "location", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Location { get; set; }

        /// <summary>
        /// Mandatory Attachment, bool
        /// </summary>
        [JsonProperty(PropertyName = "mandatory_attachment", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? MandatoryAttachment { get; set; }

        /// <summary>
        /// Meta, X4000
        /// </summary>
        [JsonProperty(PropertyName = "meta", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Meta { get; set; }

        /// <summary>
        /// Hide price (mobile listings), bool
        /// </summary>
        [JsonProperty(PropertyName = "mobile_hide_price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? MobileHidePrice { get; set; }

        /// <summary>
        /// Mobile picture, X40
        /// </summary>
        [JsonProperty(PropertyName = "mobile_picture", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string MobilePicture { get; set; }

        /// <summary>
        /// Mobile picture type, X40
        /// </summary>
        [JsonProperty(PropertyName = "mobile_picture_type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string MobilePictureType { get; set; }

        /// <summary>
        /// Model,cmdb_model reference
        /// </summary>
        [JsonProperty("model", NullValueHandling = NullValueHandling.Ignore)]
        public ReferenceLink Model { get; set; }

        /// <summary>
        /// Name, X100
        /// </summary>
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Name { get; set; }

        /// <summary>
        /// Hide Attachment, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_attachment_v2", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoAttachmentV2 { get; set; }

        /// <summary>
        /// No cart, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_cart", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoCart { get; set; }

        /// <summary>
        /// Hide 'Add to Cart', bool
        /// </summary>
        [JsonProperty(PropertyName = "no_cart_v2", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoCartV2 { get; set; }

        /// <summary>
        /// Hide Delivery time, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_delivery_time_v2", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoDeliveryTimeV2 { get; set; }

        /// <summary>
        /// No order, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_order", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoOrder { get; set; }

        /// <summary>
        /// No order now, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_order_now", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoOrderNow { get; set; }

        /// <summary>
        /// No proceed checkout, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_proceed_checkout", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoProceedCheckout { get; set; }

        /// <summary>
        /// No quantity, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_quantity", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoQuantity { get; set; }

        /// <summary>
        /// Hide Quantity, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_quantity_v2", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoQuantityV2 { get; set; }

        /// <summary>
        /// No search, bool
        /// </summary>
        [JsonProperty(PropertyName = "no_search", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoSearch { get; set; }

        /// <summary>
        /// Hide 'Add to Wish List', bool
        /// </summary>
        [JsonProperty(PropertyName = "no_wishlist_v2", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? NoWishlistV2 { get; set; }

        /// <summary>
        /// Omit price in cart, bool
        /// </summary>
        [JsonProperty("omit_price", NullValueHandling = NullValueHandling.Ignore)]
        public bool? OmitPrice { get; set; }

        /// <summary>
        /// Order, int
        /// </summary>
        [JsonProperty(PropertyName = "order", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? Order { get; set; }

        /// <summary>
        /// Ordered item link, sc_ordered_item_link reference
        /// </summary>
        [JsonProperty(PropertyName = "ordered_item_link", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink OrderedItemLink { get; set; }

        /// <summary>
        /// Owner, sys_user reference
        /// </summary>
        [JsonProperty(PropertyName = "owner", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Owner { get; set; }

        /// <summary>
        /// Picture, X40
        /// </summary>
        [JsonProperty(PropertyName = "picture", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Picture { get; set; }

        /// <summary>
        /// Preview link, X255
        /// </summary>
        [JsonProperty(PropertyName = "preview", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Preview { get; set; }

        /// <summary>
        /// Price, X20
        /// </summary>
        [JsonProperty(PropertyName = "price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Price { get; set; }

        /// <summary>
        /// Published item, sc_cat_item reference
        /// </summary>
        [JsonProperty(PropertyName = "published_ref", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink PublishedRef { get; set; }

        /// <summary>
        /// Recurring price frequency, X40
        /// </summary>
        [JsonProperty(PropertyName = "recurring_frequency", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RecurringFrequency { get; set; }

        /// <summary>
        /// Recurring price, X20
        /// </summary>
        [JsonProperty(PropertyName = "recurring_price", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RecurringPrice { get; set; }

        /// <summary>
        /// Request method, X40
        /// </summary>
        [JsonProperty(PropertyName = "request_method", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string RequestMethod { get; set; }

        /// <summary>
        /// Roles, X255
        /// </summary>
        [JsonProperty(PropertyName = "roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Roles { get; set; }

        /// <summary>
        /// Catalogs, X4000
        /// </summary>
        [JsonProperty(PropertyName = "sc_catalogs", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ScCatalogs { get; set; }

        /// <summary>
        /// Created from item design, sc_ic_item_staging reference
        /// </summary>
        [JsonProperty(PropertyName = "sc_ic_item_staging", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ScIcItemStaging { get; set; }        
        
        /// <summary>
        /// Published version, integer
        /// </summary>
        [JsonProperty(PropertyName = "sc_ic_version", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public int? ScIcVersion { get; set; }

        /// <summary>
        /// Associated template, catalog template reference
        /// </summary>
        [JsonProperty(PropertyName = "sc_template", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink ScTemplate { get; set; }

        /// <summary>
        /// Short description, X200
        /// </summary>
        [JsonProperty(PropertyName = "short_description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Expand help for all questions, bool
        /// </summary>
        [JsonProperty(PropertyName = "show_variable_help_on_load", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? ShowVariableHelpOnLoad { get; set; }

        /// <summary>
        /// Start closed, bool
        /// </summary>
        [JsonProperty(PropertyName = "start_closed", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? StartClosed { get; set; }

        /// <summary>
        /// State, X40
        /// </summary>
        [JsonProperty(PropertyName = "state", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string State { get; set; }

        /// <summary>
        /// Taxonomy topic, Topic reference
        /// </summary>
        [JsonProperty(PropertyName = "taxonomy_topic", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink TaxonomyTopic { get; set; }

        /// <summary>
        /// Template, X32 reference
        /// </summary>
        [JsonProperty(PropertyName = "template", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Template { get; set; }

        /// <summary>
        /// Template Manager roles, X255
        /// </summary>
        [JsonProperty(PropertyName = "template_manager_roles", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string TemplateManagerRoles
        { get; set; }

        /// <summary>
        /// Type, X40
        /// </summary>
        [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Type { get; set; }

        /// <summary>
        /// Use cart layout, bool
        /// </summary>
        [JsonProperty(PropertyName = "use_sc_layout", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? UseScLayout { get; set; }

        /// <summary>
        /// Vendor, X32 reference to company table
        /// </summary>
        [JsonProperty(PropertyName = "vendor", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Vendor { get; set; }

        /// <summary>
        /// Visible on Bundles, bool
        /// </summary>
        [JsonProperty(PropertyName = "visible_bundle", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? VisibleBundle { get; set; }

        /// <summary>
        /// Visible on Guides, bool
        /// </summary>
        [JsonProperty(PropertyName = "visible_guide", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? VisibleGuide { get; set; }

        /// <summary>
        /// Visible elsewhere, bool
        /// </summary>
        [JsonProperty(PropertyName = "visible_standalone", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? VisibleStandalone { get; set; }

        /// <summary>
        /// Workflow, X32, wf_workflow reference
        /// </summary>
        [JsonProperty(PropertyName = "workflow", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Workflow { get; set; }
    }
}
