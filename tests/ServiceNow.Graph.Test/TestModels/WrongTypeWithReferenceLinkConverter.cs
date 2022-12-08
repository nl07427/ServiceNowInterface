using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.TestModels
{
    /// <summary>
    /// A class for testing the invalid serialization exception for the ReferenceLinkConverter.
    /// </summary>
    [JsonConverter(typeof(ReferenceLinkConverter))]
    public class WrongTypeWithReferenceLinkConverter: AbstractEntityType
    {
    }
}
