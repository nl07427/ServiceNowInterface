using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Serialization;
using Newtonsoft.Json;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// Test class for testing serialization of an IEnumerable of Date.
    /// </summary>
    public interface ICollectionPageInstance : ICollectionPage<DerivedTypeClass>
    {
    }
}
