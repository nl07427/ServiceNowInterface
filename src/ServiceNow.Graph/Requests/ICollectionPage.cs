using System.Collections.Generic;

namespace ServiceNow.Graph.Requests
{
    /// <summary>Interface for collection pages.</summary>
    /// <typeparam name="T">The type of the collection.</typeparam>
    public interface ICollectionPage<T> : IList<T>
    {
        /// <summary>The current page of the collection.</summary>
        IList<T> CurrentPage { get; }

        /// <summary>The additional data property bag.</summary>
        IDictionary<string, object> AdditionalData { get; set; }
    }
}
