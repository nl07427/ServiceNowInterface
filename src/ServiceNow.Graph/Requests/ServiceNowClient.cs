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
        /// <param name="nameSpace">API namespace, for example the value 'now'</param>
        /// <param name="apiName">The API name, for example 'table'</param>
        /// <param name="authenticationProvider"></param>
        /// <param name="httpProvider"></param>
        /// <param name="version"></param>
        public ServiceNowClient(string domain, string nameSpace, string apiName,  IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null, string version = "") : base(domain, nameSpace, apiName, authenticationProvider, httpProvider, version)
        {
        }

        /// <summary>
        /// Gets the UserGroupsCollections request builder
        /// </summary>
        public IUserGroupsCollectionRequestBuilder UserGroups =>  new UserGroupsCollectionRequestBuilder($"{BaseAddress}/sys_user_group"   , this);

        /// <summary>
        /// Gets the Users Collections request builder
        /// </summary>
        public IUsersCollectionRequestBuilder Users => new UsersCollectionRequestBuilder($"{BaseAddress}/sys_user" , this);

        /// <summary>
        /// Get the group memberships collection request builder
        /// </summary>
        public IMembershipsCollectionRequestBuilder Memberships => new MembershipsCollectionRequestBuilder($"{BaseAddress}/sys_user_grmember" ,  this);

        /// <inheritdoc />
        public ICatalogItemOptionMtomsCollectionRequestBuilder VariableOwnerships => new CatalogItemOptionMtomsCollectionRequestBuilder($"{BaseAddress}/sc_item_option_mtom" , this);

        /// <inheritdoc />
        public ICatalogOptionsCollectionRequestBuilder CatalogOptions => new CatalogOptionsCollectionRequestBuilder($"{BaseAddress}/sc_item_option", this);

        /// <inheritdoc />
        public ICatalogRequestsCollectionRequestBuilder CatalogRequests => new CatalogRequestsCollectionRequestBuilder($"{BaseAddress}/sc_request", this);

        /// <inheritdoc />
        public ICatalogTasksCollectionRequestBuilder CatalogTasks => new CatalogTasksCollectionRequestBuilder($"{BaseAddress}/sc_task" , this);

        /// <inheritdoc />
        public IRequestItemsCollectionRequestBuilder RequestItems => new RequestItemsCollectionRequestBuilder($"{BaseAddress}/sc_req_item", this);

        /// <inheritdoc />
        public ITasksCollectionRequestBuilder Tasks => new TasksCollectionRequestBuilder($"{BaseAddress}/task", this);

        /// <inheritdoc />
        public IVariablesCollectionRequestBuilder Variables => new VariablesCollectionRequestBuilder($"{BaseAddress}/sc_item_option_mtom" , this);

        /// <inheritdoc />
        public ILocationsCollectionRequestBuilder Locations => new LocationsCollectionRequestBuilder($"{BaseAddress}/cmn_location", this);

        /// <inheritdoc />
        public IServiceCatalogsCollectionRequestBuilder ServiceCatalogs => new ServiceCatalogsCollectionRequestBuilder($"{BaseAddress}/sc_catalog" , this);

        /// <inheritdoc />
        public ICatalogItemsCollectionRequestBuilder CatalogItems => new CatalogItemsCollectionRequestBuilder($"{BaseAddress}/sc_cat_item", this);

        /// <inheritdoc />
        public IOrderGuidesCollectionRequestBuilder OrderGuides => new OrderGuidesCollectionRequestBuilder($"{BaseAddress}/sc_cat_item_guide", this);

        /// <inheritdoc />
        public IDepartmentsCollectionRequestBuilder Departments => new DepartmentsCollectionRequestBuilder($"{BaseAddress}/cmn_department" , this);

        /// <inheritdoc />
        public ICostCentersCollectionRequestBuilder CostCenters => new CostCentersCollectionRequestBuilder($"{BaseAddress}/cmn_cost_center", this);

        /// <inheritdoc />
        public ICompaniesCollectionRequestBuilder Companies => new CompaniesCollectionRequestBuilder($"{BaseAddress}/core_company" , this);
    }
}
