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
        /// <param name="url"></param>
        /// <param name="authenticationProvider"></param>
        /// <param name="httpProvider"></param>
        /// <param name="version"></param>
        public ServiceNowClient(string url, IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null, string version = "") : base(url, authenticationProvider, httpProvider, version)
        {
        }

        /// <summary>
        /// Gets the UserGroupsCollections request builder
        /// </summary>
        public IUserGroupsCollectionRequestBuilder UserGroups =>  new UserGroupsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sys_user_group")  , this);

        /// <summary>
        /// Gets the Users Collections request builder
        /// </summary>
        public IUsersCollectionRequestBuilder Users => new UsersCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sys_user") , this);

        /// <summary>
        /// Get the group memberships collection request builder
        /// </summary>
        public IMembershipsCollectionRequestBuilder Memberships => new MembershipsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sys_user_grmember")  , this);

        /// <inheritdoc />
        public ICatalogItemOptionMtomsCollectionRequestBuilder VariableOwnerships => new CatalogItemOptionMtomsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_item_option_mtom") , this);

        /// <inheritdoc />
        public ICatalogOptionsCollectionRequestBuilder CatalogOptions => new CatalogOptionsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_item_option") , this);

        /// <inheritdoc />
        public ICatalogRequestsCollectionRequestBuilder CatalogRequests => new CatalogRequestsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_request")  , this);

        /// <inheritdoc />
        public ICatalogTasksCollectionRequestBuilder CatalogTasks => new CatalogTasksCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_task") , this);

        /// <inheritdoc />
        public IRequestItemsCollectionRequestBuilder RequestItems => new RequestItemsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_req_item")  , this);

        /// <inheritdoc />
        public ITasksCollectionRequestBuilder Tasks => new TasksCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "task")  , this);

        /// <inheritdoc />
        public IVariablesCollectionRequestBuilder Variables => new VariablesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "item_option_new") , this);

        /// <inheritdoc />
        public ILocationsCollectionRequestBuilder Locations => new LocationsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "cmn_location")  , this);

        /// <inheritdoc />
        public IServiceCatalogsCollectionRequestBuilder ServiceCatalogs => new ServiceCatalogsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_catalog") , this);

        /// <inheritdoc />
        public ICatalogItemsCollectionRequestBuilder CatalogItems => new CatalogItemsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_cat_item")  , this);

        /// <inheritdoc />
        public IOrderGuidesCollectionRequestBuilder OrderGuides => new OrderGuidesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "sc_cat_item_guide") , this);

        /// <inheritdoc />
        public IDepartmentsCollectionRequestBuilder Departments => new DepartmentsCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "cmn_department") , this);

        /// <inheritdoc />
        public ICostCentersCollectionRequestBuilder CostCenters => new CostCentersCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, "cmn_cost_center") , this);

        /// <inheritdoc />
        public ICompaniesCollectionRequestBuilder Companies => new CompaniesCollectionRequestBuilder(string.Format(Constants.ApiUrlFormatString, Url, Version) + "core_company", this);
    }
}
