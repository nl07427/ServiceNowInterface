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
        IUserGroupsCollectionRequestBuilder UserGroups { get; }

        /// <summary>
        /// Get the user collection request builder
        /// </summary>
        IUsersCollectionRequestBuilder Users { get; }

        /// <summary>
        /// Get the group memberships collection request builder
        /// </summary>
        IMembershipsCollectionRequestBuilder Memberships { get; }

        /// <summary>
        /// Get the attachments collection request builder
        /// </summary>
        IAttachmentsCollectionRequestBuilder Attachments { get; }

        /// <summary>
        /// Get the profiles collection request builder
        /// </summary>
        ILiveProfilesCollectionRequestBuilder Profiles { get; }

        /// <summary>
        /// Get the M:N variable ownership collection request builder
        /// </summary>
        ICatalogItemOptionMtomsCollectionRequestBuilder VariableOwnerships { get; }

        /// <summary>
        /// Catalog options collection request builder
        /// </summary>
        ICatalogOptionsCollectionRequestBuilder CatalogOptions { get; }

        /// <summary>
        /// Catalog requests collection request builder
        /// </summary>
        ICatalogRequestsCollectionRequestBuilder CatalogRequests { get; }

        /// <summary>
        /// Catalog tasks collection request builder
        /// </summary>
        ICatalogTasksCollectionRequestBuilder CatalogTasks { get; }

        /// <summary>
        /// Questions collection request builder
        /// </summary>
        IQuestionsCollectionRequestBuilder Questions { get; }

        /// <summary>
        /// Request items collection request builder
        /// </summary>
        IRequestItemsCollectionRequestBuilder RequestItems { get; }

        /// <summary>
        /// Tasks collection request builder
        /// </summary>
        ITasksCollectionRequestBuilder Tasks { get; }

        /// <summary>
        /// Variables collection request builder
        /// </summary>
        IVariablesCollectionRequestBuilder Variables { get; }

        /// <summary>
        /// Locations collection request builder
        /// </summary>
        ILocationsCollectionRequestBuilder Locations { get; }

        /// <summary>
        /// Service catalogs collection request builder
        /// </summary>
        IServiceCatalogsCollectionRequestBuilder ServiceCatalogs { get; }

        /// <summary>
        /// Catalog items collection request builder
        /// </summary>
        ICatalogItemsCollectionRequestBuilder CatalogItems { get; }

        /// <summary>
        /// Order guides collection request builder
        /// </summary>
        IOrderGuidesCollectionRequestBuilder OrderGuides { get; }

        /// <summary>
        /// Order guides collection request builder
        /// </summary>
        IIncidentsCollectionRequestBuilder Incidents { get; }

        /// <summary>
        /// Departments collection request builder
        /// </summary>
        IDepartmentsCollectionRequestBuilder Departments { get; }

        /// <summary>
        /// Cost centers collection request builder
        /// </summary>
        ICostCentersCollectionRequestBuilder CostCenters { get; }

        /// <summary>
        /// Companies collection request builder
        /// </summary>
        ICompaniesCollectionRequestBuilder Companies { get; }

        /// <summary>
        /// ConfigurationItem collection request builder
        /// </summary>
        IConfigurationItemsCollectionRequestBuilder ConfigurationItems { get; }

        /// <summary>
        /// Roles collection request builder
        /// </summary>
        IRolesCollectionRequestBuilder Roles { get; }

        /// <summary>
        /// RoleHasRoles collection request builder
        /// </summary>
        IRoleHasRolesCollectionRequestBuilder RoleHasRoles { get; }

        /// <summary>
        /// GroupHasRoles collection request builder
        /// </summary>
        IGroupHasRolesCollectionRequestBuilder GroupHasRoles { get; }

        /// <summary>
        /// UserHasRoles collection request builder
        /// </summary>
        IUserHasRolesCollectionRequestBuilder UserHasRoles { get; }
    }
}
