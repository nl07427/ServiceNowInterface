using Newtonsoft.Json;

namespace ServiceNow.Graph.Models
{
    /// <summary>
    /// ServiceNow sc_catalog
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ServiceCatalog : ApplicationFile
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ServiceCatalog()
        {
            ObjectType = "sc_catalog";
        }

        /// <summary>
        /// Description, X4000
        /// </summary>
        [JsonProperty(PropertyName = "description", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Description { get; set; }

        /// <summary>
        /// Enable Wish List, Bool
        /// </summary>
        [JsonProperty(PropertyName = "enable_wish_list", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public bool? EnableWishList { get; set; }

        /// <summary>
        /// Title, X100
        /// </summary>
        [JsonProperty(PropertyName = "title", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Title { get; set; }

        /// <summary>
        /// Desktop image, X40
        /// </summary>
        [JsonProperty(PropertyName = "desktop_image", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DesktopImage { get; set; }

        /// <summary>
        /// 'Catalog Home' Page, X3000
        /// </summary>
        [JsonProperty(PropertyName = "desktop_home_page", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DesktopHomePage { get; set; }

        /// <summary>
        /// Editors, X1024
        /// </summary>
        [JsonProperty(PropertyName = "editors", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string Editors { get; set; }

        /// <summary>
        /// Manager, sys_user reference
        /// </summary>
        [JsonProperty(PropertyName = "manager", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public ReferenceLink Manager { get; set; }

        /// <summary>
        /// Active, bool
        /// </summary>
        [JsonProperty("active", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Active { get; set; }

        /// <summary>
        /// 'Continue Shopping' page, X3000
        /// </summary>
        [JsonProperty(PropertyName = "desktop_continue_shopping", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string DesktopContinueShopping { get; set; }

        /// <summary>
        /// Background Color, X40
        /// </summary>
        [JsonProperty(PropertyName = "background_color", NullValueHandling = NullValueHandling.Ignore, Required = Required.Default)]
        public string BackgroundColor { get; set; }
    }
}
