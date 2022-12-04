using System;
using Newtonsoft.Json.Linq;
using ServiceNow.Graph.Authentication;
using ServiceNow.Graph.Requests;
using Xunit;

namespace ServiceNow.Graph.Test.ServiceNow.Graph.Test.Requests
{
    public class UserTests
    {
        private ClientCredentialProvider CredentialProvider { get; }
        private ServiceNowClient Client { get; }
        /*
        public UserTests()
        {
            var directoryInfo = System.IO.Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory);
            if (directoryInfo == null) return;
            var workingDirectory =
                directoryInfo.FullName;
            var secrets = JObject.Parse(System.IO.File.ReadAllText($"{workingDirectory}\\secrets.json"));

            CredentialProvider = new ClientCredentialProvider(secrets.SelectToken("Domain").ToString(), secrets.SelectToken("ClientId").ToString(),
                secrets.SelectToken("ClientSecret").ToString(), secrets.SelectToken("UserName").ToString(), secrets.SelectToken("UserPassword").ToString());

            Client = new ServiceNowClient(secrets.SelectToken("Domain").ToString(), "now", "table", CredentialProvider);
        }

        [Fact]
        public void UserAllTest()
        {
            var ucrb = Client.Users;
            var ucr = ucrb.Request();
            ucr.Select("sys_id,user_id");
            var page = ucr.GetAsync().GetAwaiter().GetResult();
            if (page == null || page.CurrentPage == null) return;
            var outcome = page.CurrentPage;
            var nextpagerequest = page.NextPageRequest;
            while(nextpagerequest != null)
            {
                var np = nextpagerequest.GetAsync().GetAwaiter().GetResult();
                if (np != null && np.CurrentPage.Count > 0)
                {
                }
                nextpagerequest = np.NextPageRequest;
            }
        }*/
    }
}
