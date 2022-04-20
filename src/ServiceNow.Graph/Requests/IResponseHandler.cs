using System.Net.Http;
using System.Threading.Tasks;

namespace ServiceNow.Graph.Requests
{
    /// <summary>
    /// The interface required for all response handlers.
    /// </summary>
    public interface IResponseHandler
    {
        /// <summary>
        /// Process raw HTTP response into the requested domain type.
        /// </summary>
        /// <typeparam name="T">The type to return</typeparam>
        /// <param name="response">The HttpResponseMessage to handle.</param>
        /// <returns></returns>
        Task<T> HandleResponse<T>(HttpResponseMessage response);
    }
}
