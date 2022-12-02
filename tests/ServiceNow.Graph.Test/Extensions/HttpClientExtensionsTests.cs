using System;
using System.Linq;
using System.Net.Http;
using ServiceNow.Graph.Extensions;
using ServiceNow.Graph.Requests;
using Xunit;

namespace ServiceNow.Graph.Test.Extensions
{
    public class HttpClientExtensionsTests
    {
        [Fact]
        public void SetFeatureFlag_should_add_new_flag_to_featureflag_header()
        {
            HttpClient client = new HttpClient();
            client.SetFeatureFlag(FeatureFlag.LongRunningOperationHandler);

            string expectedHeaderValue = Enum.Format(typeof(FeatureFlag), FeatureFlag.LongRunningOperationHandler, "x");

            Assert.True(client.DefaultRequestHeaders.Contains(Constants.Headers.FeatureFlag));
            Assert.True(client.DefaultRequestHeaders.GetValues(Constants.Headers.FeatureFlag).Count().Equals(1));
            Assert.Equal(client.DefaultRequestHeaders.GetValues(Constants.Headers.FeatureFlag).First(), expectedHeaderValue);
        }

        [Fact]
        public void SetFeatureFlag_should_add_flag_to_existing_featureflag_header_values()
        {
            FeatureFlag flags = FeatureFlag.AuthHandler | FeatureFlag.CompressionHandler | FeatureFlag.RetryHandler | FeatureFlag.RedirectHandler;

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add(Constants.Headers.FeatureFlag, Enum.Format(typeof(FeatureFlag), FeatureFlag.DefaultHttpProvider, "x"));
            client.SetFeatureFlag(flags);

            // 0000004F
            string expectedHeaderValue = Enum.Format(typeof(FeatureFlag), flags |= FeatureFlag.DefaultHttpProvider, "x");

            Assert.True(client.DefaultRequestHeaders.Contains(Constants.Headers.FeatureFlag));
            Assert.True(client.DefaultRequestHeaders.GetValues(Constants.Headers.FeatureFlag).Count().Equals(1));
            Assert.Equal(client.DefaultRequestHeaders.GetValues(Constants.Headers.FeatureFlag).First(), expectedHeaderValue);
        }

        [Fact]
        public void ContainsFeatureFlag_should_return_true_for_added_flag()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add(Constants.Headers.FeatureFlag, Enum.Format(typeof(FeatureFlag), FeatureFlag.CompressionHandler, "x"));
            
            Assert.True(client.ContainsFeatureFlag(FeatureFlag.CompressionHandler));
        }
    }
}
