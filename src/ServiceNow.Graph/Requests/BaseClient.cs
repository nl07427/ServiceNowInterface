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
        private string _ns;
        private string _apiName;
        private string _baseAddress;

        /// <summary>
        /// Constructs a new <see cref="BaseClient"/>.
        /// </summary>
        /// <param name="domain">The domain. For example, customer.service-now.com"</param>
        /// <param name="nameSpace">API namespace, for example the value 'now'</param>
        /// <param name="apiName">The API name, for example 'table'</param>
        /// <param name="authenticationProvider">The <see cref="IAuthenticationProvider"/> for authenticating request messages.</param>
        /// <param name="httpProvider">The <see cref="IHttpProvider"/> for sending requests.</param>
        /// <param name="version"></param>
        protected BaseClient(string domain,
            string nameSpace,
            string apiName,
            IAuthenticationProvider authenticationProvider,
            IHttpProvider httpProvider = null, string version = "")
        {
            Domain = domain;
            Version = version;
            Namespace = nameSpace;
            ApiName = apiName;
            _baseAddress = DetermineBaseAddress();
            AuthenticationProvider = authenticationProvider;
            HttpProvider = httpProvider ?? new HttpProvider(domain, nameSpace, apiName, version, new Serializer(new JsonSerializerSettings
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
        /// <param name="nameSpace">API namespace, for example the value 'now'</param>
        /// <param name="apiName">The API name, for example 'table'</param>
        /// <param name="version">The version of the ServiceNow API, for example "now" for the latest endpoint</param>
        /// <param name="httpClient">The custom <see cref="HttpClient"/> to be used for making requests</param>
        public BaseClient(
            string domain,
            string nameSpace,
            string apiName,
            string version,
            HttpClient httpClient)
        {
            Domain = domain;
            Namespace = nameSpace;
            ApiName = apiName;
            Version = version;
            _baseAddress = DetermineBaseAddress();
            HttpProvider = new SimpleHttpProvider(httpClient, domain, nameSpace, apiName, version);
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
        public string BaseAddress => _baseAddress;


        /// <summary>
        /// Gets the version of the ServiceNow api.
        /// </summary>
        public string Version
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

        public string Namespace
        {
            get => _ns;
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
                                DetailedMessage = ErrorConstants.Messages.NamespaceMissing
                            }
                        });
                }

                _ns = value.ToLower();
            }
        }

        public string ApiName
        {
            get => _apiName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ServiceException(
                        new Error
                        {
                            ErrorDetail = new ErrorDetail
                            {
                                Message = ErrorConstants.Codes.InvalidRequest,
                                DetailedMessage = ErrorConstants.Messages.ApiNameMissing
                            }
                        });
                }

                _apiName = value.ToLower();
            }
        }

        private string DetermineBaseAddress()
        {
            return  string.IsNullOrEmpty(Version)
                ? string.Format(Constants.ApiUrlFormatWithNoVersionString, Domain, Namespace, ApiName)
                : string.Format(Constants.ApiUrlFormatString, Domain, Namespace, Version, ApiName);
        }
    }
}
