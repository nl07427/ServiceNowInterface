using Newtonsoft.Json;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Test.TestModels
{
    [JsonConverter(typeof(DerivedTypeConverter))]
    public class NoDefaultConstructor
    {
        static NoDefaultConstructor()
        {

        }

        public NoDefaultConstructor(string parameter)
        {

        }
    }
}
