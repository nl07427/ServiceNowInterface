namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// Interface IServiceNowClient
    /// </summary>
    public interface IServiceNowClient
    {
        /// <summary>
        /// Gets the UserGroups request builder
        /// </summary>
        IUserGroupsCollectionRequestBuilder UserGroups(string version = "");

        /// <summary>
        /// Get the user collection request builder
        /// </summary>
        IUsersCollectionRequestBuilder Users(string version = "");

        /// <summary>
        /// Get the group memberships collection request builder
        /// </summary>
        IMembershipsCollectionRequestBuilder Memberships(string version = "");

        /// <summary>
        /// Get the M:N variable ownership collection request builder
        /// </summary>
        ICatalogItemOptionMtomsCollectionRequestBuilder VariableOwnerships(string version = "");

        /// <summary>
        /// Catalog options collection request builder
        /// </summary>
        ICatalogOptionsCollectionRequestBuilder CatalogOptions(string version = "");

        /// <summary>
        /// Catalog requests collection request builder
        /// </summary>
        ICatalogRequestsCollectionRequestBuilder CatalogRequests(string version = "");

        /// <summary>
        /// Catalog tasks collection request builder
        /// </summary>
        ICatalogTasksCollectionRequestBuilder CatalogTasks(string version = "");

        /// <summary>
        /// Request items collection request builder
        /// </summary>
        IRequestItemsCollectionRequestBuilder RequestItems(string version = "");

        /// <summary>
        /// Tasks collection request builder
        /// </summary>
        ITasksCollectionRequestBuilder Tasks(string version = "");

        /// <summary>
        /// Variables collection request builder
        /// </summary>
        IVariablesCollectionRequestBuilder Variables(string version = "");

        /// <summary>
        /// Locations collection request builder
        /// </summary>
        ILocationsCollectionRequestBuilder Locations(string version = "");

        /// <summary>
        /// Service catalogs collection request builder
        /// </summary>
        IServiceCatalogsCollectionRequestBuilder ServiceCatalogs(string version = "");

        /// <summary>
        /// Catalog items collection request builder
        /// </summary>
        ICatalogItemsCollectionRequestBuilder CatalogItems(string version = "");

        /// <summary>
        /// Order guides collection request builder
        /// </summary>
        IOrderGuidesCollectionRequestBuilder OrderGuides(string version = "");

        /// <summary>
        /// Departments collection request builder
        /// </summary>
        IDepartmentsCollectionRequestBuilder Departments(string version = "");

        /// <summary>
        /// Cost centers collection request builder
        /// </summary>
        ICostCentersCollectionRequestBuilder CostCenters(string version = "");

        /// <summary>
        /// Companies collection request builder
        /// </summary>
        ICompaniesCollectionRequestBuilder Companies(string version = "");

        /// <summary>
        /// Attachments collection request builder
        /// </summary>
        IAttachmentsCollectionRequestBuilder Attachments(string version = "");

        /// <summary>
        /// Business units collection request builder
        /// </summary>
        IBusinessUnitsCollectionRequestBuilder BusinessUnits(string version = "");

        /// <summary>
        /// Incidents collection request builder
        /// </summary>
        IIncidentsCollectionRequestBuilder Incidents(string version = "");

        /// <summary>
        /// Roles collection request builder
        /// </summary>
        IRolesCollectionRequestBuilder Roles(string version = "");

        /// <summary>
        /// UserHasRoles collection request builder
        /// </summary>
        IUserHasRolesCollectionRequestBuilder UserHasRoles(string version = "");

        /// <summary>
        /// Group has roles collection request builder
        /// </summary>
        IGroupHasRolesCollectionRequestBuilder GroupHasRoles(string version = "");

        /// <summary>
        ///Live profiles collection request builder
        /// </summary>
        ILiveProfilesCollectionRequestBuilder LiveProfiles(string version = "");

        /// <summary>
        ///CMDB Configuration items, table cmdb_ci
        /// </summary>
        IConfigurationItemsCollectionRequestBuilder ConfigurationItems(string version = "");

        /// <summary>
        ///Contained roles, role contains table: sys_user_role_contains
        /// </summary>
        IRoleHasRolesCollectionRequestBuilder RoleHasRoles(string version = "");

        /// <summary>
        ///Building, cmn_building table
        /// </summary>
        IBuildingCollectionRequestBuilder Buildings(string version = "");
    }
}
