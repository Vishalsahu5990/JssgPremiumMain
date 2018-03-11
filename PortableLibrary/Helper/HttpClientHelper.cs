using System;
using System.Net.Http;
using System.Net.Http.Headers;
using ModernHttpClient;

namespace DataAccessLayer.Helper
{
    public class HttpClientHelper
    {
        /// <summary>
        /// Return the Client object with basic parameters
        /// </summary>
        /// <returns>The client.</returns>
        public static HttpClient GetHttpClient()
        {
            var handler = new NativeMessageHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri(URL.APIBaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CommonUtility.RequestFormat));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue(CommonUtility.EncodingFormat));

            return client;
        }

        /// <summary>
        /// Returns HttpClient with username and password authorization
        /// It performs Basic Auth
        /// </summary>
        /// <returns>The http client.</returns>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public static HttpClient GetAuthHttpClientWithCredentials(string username, string password)
        {
            //Gets the client object
            var client = GetHttpClient();

            //Set Authorization header
            //client.DefaultRequestHeaders.Authorization = client.ToAuthHeaderValue(username, password);

            return client;
        }

        /// <summary>
        /// Returns HttpClient with access token
        /// It performs Auth with bearer token
        /// </summary>
        /// <returns>The http client.</returns>
        /// <param name="token">Token.</param>
        public static HttpClient GetHttpClientAuthWithToken(string token = null)
        {
            //Gets the client object
            var client = GetHttpClient();

            //Set Authorization header
            //client.DefaultRequestHeaders.Authorization = client.ToAuthHeaderValue(token);

            return client;
        }
    }
}
