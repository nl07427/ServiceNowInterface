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
    }
}
