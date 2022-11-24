using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("ServiceNow.Graph.Test")]
namespace ServiceNow.Graph.Exceptions
{
    internal static class ErrorConstants
    {
        internal static class Codes
        {
            internal static readonly string GeneralException = "generalException";

            internal static readonly string InvalidRequest = "invalidRequest";

            internal static readonly string ItemNotFound = "itemNotFound";

            internal static readonly string NotAllowed = "notAllowed";

            internal static readonly string Timeout = "timeout";

            internal static readonly string TooManyRedirects = "tooManyRedirects";

            internal static readonly string TooManyRetries = "tooManyRetries";

            internal static readonly string MaximumValueExceeded = "MaximumValueExceeded";

            internal static readonly string InvalidArgument = "invalidArgument";
        }

        internal static class Messages
        {
            internal static readonly string AuthenticationProviderMissing = "Authentication provider is required before sending a request.";

            internal static readonly string BaseUrlMissing = "Base URL cannot be null or empty.";

            internal static readonly string DomainMissing = "Domain cannot be null or empty.";

            internal static readonly string InvalidTypeForDateConverter = "DateConverter can only serialize objects of type Date.";

            internal static readonly string InvalidTypeForReferenceLinkConverter = "ReferenceLinkConverter can only serialize objects of type ReferenceLink.";

            internal static readonly string LocationHeaderNotSetOnRedirect = "Location header not present in redirection response.";

            internal static readonly string OverallTimeoutCannotBeSet = "Overall timeout cannot be set after the first request is sent.";

            internal static readonly string RequestTimedOut = "The request timed out.";

            internal static readonly string RequestUrlMissing = "Request URL is required to send a request.";

            internal static readonly string TooManyRedirectsFormatString = "More than {0} redirects encountered while sending the request.";

            internal static readonly string TooManyRetriesFormatString = "More than {0} retries encountered while sending the request.";

            internal static readonly string UnableToCreateInstanceOfTypeFormatString = "Unable to create an instance of type {0}.";

            internal static readonly string UnableToDeserializeDate = "Unable to deserialize the returned Date.";

            internal static readonly string UnableToDeserializeDuration = "Unable to deserialize the returned duration.";

            internal static readonly string UnexpectedExceptionOnSend = "An error occurred sending the request.";

            internal static readonly string UnexpectedExceptionResponse = "Unexpected exception returned from the service.";

            internal static readonly string MaximumValueExceeded = "{0} exceeds the maximum value of {1}.";

            public static readonly string InvalidProxyArgument = "Proxy cannot be set more once. Proxy can only be set on the proxy or defaultHttpHandler argument and not both.";
        }
    }
}
