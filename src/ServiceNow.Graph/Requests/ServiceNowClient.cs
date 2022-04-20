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
        /// <param name="version"></param>
        public ServiceNowClient(string domain, IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null, string version = "now") : base(domain, authenticationProvider, httpProvider, version)
        {
        }

        /// <summary>
        /// Gets the UserGroupsCollections request builder
        /// </summary>
        public IUserGroupsCollectionRequestBuilder UserGroups =>  new UserGroupsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sys_user_group", this);

        /// <summary>
        /// Gets the Users Collections request builder
        /// </summary>
        public IUsersCollectionRequestBuilder Users => new UsersCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sys_user", this);

        /// <summary>
        /// Get the group memberships collection request builder
        /// </summary>
        public IMembershipsCollectionRequestBuilder Memberships => new MembershipsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sys_user_grmember", this);

        /// <summary>
        /// Get the attachments collection request builder
        /// </summary>
        public IAttachmentsCollectionRequestBuilder Attachments => new AttachmentsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "attachment", this);

        /// <summary>
        /// Get the profiles collection request builder
        /// </summary>
        public ILiveProfilesCollectionRequestBuilder Profiles => new LiveProfilesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/live_profile", this);

        /// <inheritdoc />
        public ICatalogItemOptionMtomsCollectionRequestBuilder VariableOwnerships => new CatalogItemOptionMtomsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_item_option_mtom", this);

        /// <inheritdoc />
        public ICatalogOptionsCollectionRequestBuilder CatalogOptions => new CatalogOptionsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_item_option", this);

        /// <inheritdoc />
        public ICatalogRequestsCollectionRequestBuilder CatalogRequests => new CatalogRequestsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_request", this);

        /// <inheritdoc />
        public ICatalogTasksCollectionRequestBuilder CatalogTasks => new CatalogTasksCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_task", this);

        /// <inheritdoc />
        public IQuestionsCollectionRequestBuilder Questions => new QuestionsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/question", this);

        /// <inheritdoc />
        public IRequestItemsCollectionRequestBuilder RequestItems => new RequestItemsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_req_item", this);

        /// <inheritdoc />
        public ITasksCollectionRequestBuilder Tasks => new TasksCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/task", this);

        /// <inheritdoc />
        public IVariablesCollectionRequestBuilder Variables => new VariablesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/item_option_new", this);

        /// <inheritdoc />
        public ILocationsCollectionRequestBuilder Locations => new LocationsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/cmn_location", this);

        /// <inheritdoc />
        public IServiceCatalogsCollectionRequestBuilder ServiceCatalogs => new ServiceCatalogsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_catalog", this);

        /// <inheritdoc />
        public ICatalogItemsCollectionRequestBuilder CatalogItems => new CatalogItemsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_cat_item", this);

        /// <inheritdoc />
        public IOrderGuidesCollectionRequestBuilder OrderGuides => new OrderGuidesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sc_cat_item_guide", this);

        /// <inheritdoc />
        public IIncidentsCollectionRequestBuilder Incidents => new IncidentsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/incident", this);

        /// <inheritdoc />
        public IDepartmentsCollectionRequestBuilder Departments => new DepartmentsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/cmn_department", this);

        /// <inheritdoc />
        public ICostCentersCollectionRequestBuilder CostCenters => new CostCentersCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/cmn_cost_center", this);

        /// <inheritdoc />
        public ICompaniesCollectionRequestBuilder Companies => new CompaniesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/core_company", this);

        /// <inheritdoc />
        public IConfigurationItemsCollectionRequestBuilder ConfigurationItems => new ConfigurationItemsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/cmdb_ci", this);

        /// <inheritdoc />
        public IRolesCollectionRequestBuilder Roles => new RolesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sys_user_role", this);

        /// <inheritdoc />
        public IRoleHasRolesCollectionRequestBuilder RoleHasRoles => new RoleHasRolesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sys_user_role_contains", this);

        /// <inheritdoc />
        public IGroupHasRolesCollectionRequestBuilder GroupHasRoles => new GroupHasRolesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sys_group_has_role", this);

        /// <inheritdoc />
        public IUserHasRolesCollectionRequestBuilder UserHasRoles => new UserHasRolesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/sys_user_has_role", this);
        
        /// <inheritdoc />
        public IBusinessUnitsCollectionRequestBuilder BusinessUnits => new BusinessUnitsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Domain, Version) + "table/business_unit", this);

    }
}
