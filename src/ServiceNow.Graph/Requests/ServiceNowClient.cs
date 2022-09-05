using ServiceNow.Graph.Authentication;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The <see cref="T:ServiceNow.Graph.Requests.ServiceNowClient"/> implementation.
    /// </summary>
    public class ServiceNowClient : BaseClient, IServiceNowClient
    {
        /// <summary>
        /// Instantiates a ServiceNowClient
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="authenticationProvider"></param>
        /// <param name="httpProvider"></param>
        public ServiceNowClient(string domain,  IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null) : base(domain,authenticationProvider, httpProvider)
        {
        }

        /// <summary>
        /// Gets the UserGroupsCollections request builder
        /// </summary>
        public IUserGroupsCollectionRequestBuilder UserGroups(string version = "")
        {
            return new UserGroupsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sys_user_group", version)   , this);
        }

        public IMembershipsCollectionRequestBuilder Memberships(string version = "")
        {
            return new MembershipsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sys_user_grmember", version)   , this);
        }

        public ICatalogItemOptionMtomsCollectionRequestBuilder VariableOwnerships(string version = "")
        {
            return new CatalogItemOptionMtomsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_item_option_mtom", version)   , this);
        }

        public ICatalogOptionsCollectionRequestBuilder CatalogOptions(string version = "")
        {
            return new CatalogOptionsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_item_option", version)   , this);
        }

        public ICatalogRequestsCollectionRequestBuilder CatalogRequests(string version = "")
        {
            return new CatalogRequestsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_request", version)   , this);
        }

        public ICatalogTasksCollectionRequestBuilder CatalogTasks(string version = "")
        {
            return new CatalogTasksCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_task", version)   , this);
        }

        public IRequestItemsCollectionRequestBuilder RequestItems(string version = "" )
        {
            return new RequestItemsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_req_item", version)   , this);
        }

        public ITasksCollectionRequestBuilder Tasks(string version = "")
        {
            return new TasksCollectionRequestBuilder(BuildRequestUrl("now", "table", "task", version)   , this);
        }

        public IVariablesCollectionRequestBuilder Variables(string version = "")
        {
            return new VariablesCollectionRequestBuilder(BuildRequestUrl("now", "table", "item_option_new", version)   , this); 
        }

        public ILocationsCollectionRequestBuilder Locations(string version = "")
        {
            return new LocationsCollectionRequestBuilder(BuildRequestUrl("now", "table", "cmn_location", version)   , this);   
        }

        public  IServiceCatalogsCollectionRequestBuilder ServiceCatalogs(string version = "")
        {
            return new ServiceCatalogsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_catalog", version)   , this);
        }

        public ICatalogItemsCollectionRequestBuilder CatalogItems(string version = "")
        {
            return new CatalogItemsCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_cat_item", version)   , this);
        }

        public IOrderGuidesCollectionRequestBuilder OrderGuides(string version = "")
        {
            return new OrderGuidesCollectionRequestBuilder(BuildRequestUrl("now", "table", "sc_cat_item_guide", version)   , this);
        }

        public IDepartmentsCollectionRequestBuilder Departments(string version = "")
        {
            return new DepartmentsCollectionRequestBuilder(BuildRequestUrl("now", "table", "cmn_department", version)   , this);
        }

        public ICostCentersCollectionRequestBuilder CostCenters(string version = "")
        {
            return new CostCentersCollectionRequestBuilder(BuildRequestUrl("now", "table", "cmn_cost_center", version)   , this);
        }

        public ICompaniesCollectionRequestBuilder Companies(string version = "")
        {
            return new CompaniesCollectionRequestBuilder(BuildRequestUrl("now", "table", "core_company", version)   , this);
        }

        public IAttachmentsCollectionRequestBuilder Attachments(string version = "")
        {
            return new AttachmentsCollectionRequestBuilder(BuildRequestUrl("now", "attachment", "", version)   , this);
        }

        public IBusinessUnitsCollectionRequestBuilder BusinessUnits(string version = "")
        {
            return new BusinessUnitsCollectionRequestBuilder(BuildRequestUrl("now", "table", "business_unit", version)   , this);
        }

        public IIncidentsCollectionRequestBuilder Incidents(string version = "")
        {
            return new IncidentsCollectionRequestBuilder(BuildRequestUrl("now", "table", "incident", version)   , this);
        }

        public IRolesCollectionRequestBuilder Roles(string version = "")
        {
            return new RolesCollectionRequestBuilder(BuildRequestUrl("now", "table", "sys_user_role", version)   , this);
        }

        public IUserHasRolesCollectionRequestBuilder UserHasRoles(string version = "")
        {
            return new UserHasRolesCollectionRequestBuilder(BuildRequestUrl("now", "table", "sys_user_has_role", version)   , this);
        }

        public IGroupHasRolesCollectionRequestBuilder GroupHasRoles(string version = "")
        {
            return new GroupHasRolesCollectionRequestBuilder(BuildRequestUrl("now", "table", "sys_group_has_role", version)   , this);
        }

        public ILiveProfilesCollectionRequestBuilder LiveProfiles(string version = "")
        {
            return new LiveProfilesCollectionRequestBuilder(BuildRequestUrl("now", "table", "live_profile", version)   , this);
        }

        /// <summary>
        /// Gets the Users Collections request builder
        /// </summary>
        public IUsersCollectionRequestBuilder Users(string version = "")
        {
            return new UsersCollectionRequestBuilder(BuildRequestUrl("now", "table", "sys_user", version)   , this);
        }
    }
}
