using System;
using System.Net.Http;
using Newtonsoft.Json;
using ServiceNow.Graph.Authentication;
using ServiceNow.Graph.Exceptions;
using ServiceNow.Graph.Serialization;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// A default <see cref="IBaseClient"/> implementation.
    /// </summary>
    public class BaseClient : IBaseClient
    {
        private string _domain;

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="domain">The domain. For example, customer.service-now.com"</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        protected BaseClient(string domain,
            IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null)
        {
            Domain = domain;
            BaseAddress = DetermineBaseAddress();
            AuthenticationProvider = authenticationProvider;
            HttpProvider = httpProvider ?? new HttpProvider(domain, new Serializer(new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                TypeNameHandling = TypeNameHandling.None,
                DateParseHandling = DateParseHandling.None,
                DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
            }));
        }

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="domain">The domain of the ServiceNow instance. For example, customer.service-now.com</param>
        /// <param name="httpClient">The custom <see cref="HttpClient"/> to be used for making requests</param>
        public BaseClient(
            string domain,
            HttpClient httpClient)
        {
            Domain = domain;
            BaseAddress = DetermineBaseAddress();
            HttpProvider = new SimpleHttpProvider(httpClient, domain);
        }

        /// <summary>
        /// Gets the <see cref="IAuthenticationProvider"/> for authenticating requests.
        /// </summary>
        public IAuthenticationProvider AuthenticationProvider { get; }

        /// <summary>
        /// Gets or sets the base domain for requests of the client.
        /// </summary>
        public string Domain
        {
            get => _domain;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                Message = ErrorConstants.Codes.InvalidRequest,
                                DetailedMessage = ErrorConstants.Messages.DomainMissing
                            }
                        });
                }

                _domain = value.TrimEnd('/');
            }
        }

        /// <summary>
        /// Gets or sets the base address for requests of the client.
        /// </summary>
        public string BaseAddress
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="IHttpProvider"/> for sending HTTP requests.
        /// </summary>
        public IHttpProvider HttpProvider { get; }

        /// <summary>
        /// Gets or Sets the <see cref="IAuthenticationProvider"/> for authenticating a single HTTP requests. 
        /// </summary>
        public Func<IAuthenticationProvider> PerRequestAuthProvider { get; set; }

        private string DetermineBaseAddress()
        {
            return $"https://{Domain}/api";
        }

        public string BuildRequestUrl(string nameSpace, string apiName, string tableName, string version)
        {
            string requestUrl = $"{BaseAddress}/{nameSpace}";
            if (!string.IsNullOrEmpty(version))
            {
                requestUrl = $"{requestUrl}/{version}";
            }
            requestUrl = $"{requestUrl}/{apiName}";
            if (!string.IsNullOrEmpty(tableName))
            {
                requestUrl = $"{requestUrl}/{tableName}";
            }

            return requestUrl;
        }
    }
}
