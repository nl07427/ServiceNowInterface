using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ServiceNow.Graph.Requests;
using ServiceNow.Graph.Serialization;
using ServiceNow.Graph.Test.TestModels.ServiceModels;
using Xunit;

namespace ServiceNow.Graph.Test.Requests
{
    public class ResponseHandlerTests
    {
        [Fact]
        public async Task HandleUserResponse()
        {
            // Arrange
            var responseHandler = new ResponseHandler(new Serializer());
            var hrm = new HttpResponseMessage()
            {
                Content = new StringContent(@"{
                    ""id"": ""123"",
                    ""givenName"": ""Joe"",
                    ""surName"": ""Brown"",
                    ""@odata.type"":""test""
                }", Encoding.UTF8, "application/json")
            };
            hrm.Headers.Add("test", "value");

            // Act
            var user = await responseHandler.HandleResponse<TestUser>(hrm);

            //Assert
            Assert.Equal("123", user.Id);
            Assert.Equal("Joe", user.GivenName);
            Assert.Equal("Brown", user.Surname);
        }
    }
}
