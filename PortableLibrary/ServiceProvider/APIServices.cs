using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Helper;
using Newtonsoft.Json;

namespace DataAccessLayer.ServiceProvider
{
    public class APIServices: IDisposable
    {
        async public Task<HttpResponseMessage> GetAsync(string url)
        {
            HttpResponseMessage responseMessage;

            var uri = new Uri(String.Join(string.Empty, URL.APIBaseAddress, url));

            using (var client = HttpClientHelper.GetHttpClient())
            {
                responseMessage = await client.GetAsync(uri);
            }

            return responseMessage;
        }

        /// <summary>
        /// Posts the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <param name="request">Request.</param>
        async public Task<HttpResponseMessage> PostAsync(string url, object request = null)
        {
            HttpResponseMessage responseMessage;

            //var uri = new Uri(String.Join(string.Empty, URL.APIBaseAddress, url));
            var uri = new Uri(URL.APIBaseAddress);

            var requestJson = (request != null) ? JsonConvert.SerializeObject(request) : string.Empty;
            var requestContent = new StringContent(requestJson, Encoding.UTF8, CommonUtility.RequestFormat);

            using (var client = HttpClientHelper.GetHttpClient())
            {
                responseMessage = await client.PostAsync(uri, requestContent);
            }

            return responseMessage;
        }

        /// <summary>
        /// Puts the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        /// <param name="request">Request.</param>
        async public Task<HttpResponseMessage> PutAsync(string url, object request)
        {
            HttpResponseMessage responseMessage;

            var uri = new Uri(String.Join(string.Empty, URL.APIBaseAddress, url));

            var requestJson = JsonConvert.SerializeObject(request);
            var requestContent = new StringContent(requestJson, Encoding.UTF8, CommonUtility.RequestFormat);

            using (var client = HttpClientHelper.GetHttpClient())
            {
                responseMessage = await client.PutAsync(uri, requestContent);
            }

            return responseMessage;
        }

        /// <summary>
        /// Deletes the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="url">URL.</param>
        async public Task<HttpResponseMessage> DeleteAsync(string url)
        {
            HttpResponseMessage responseMessage;

            var uri = new Uri(String.Join(string.Empty, URL.APIBaseAddress, url));

            using (var client = HttpClientHelper.GetHttpClient())
            {
                responseMessage = await client.DeleteAsync(uri);
            }
            return responseMessage;
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:ServiceAccessLayer.ServiceProvider.APIServices"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the
        /// <see cref="T:ServiceAccessLayer.ServiceProvider.APIServices"/>. The <see cref="Dispose"/> method leaves the
        /// <see cref="T:ServiceAccessLayer.ServiceProvider.APIServices"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the
        /// <see cref="T:ServiceAccessLayer.ServiceProvider.APIServices"/> so the garbage collector can reclaim the
        /// memory that the <see cref="T:ServiceAccessLayer.ServiceProvider.APIServices"/> was occupying.</remarks>
        public void Dispose()
        {
           
        }
    }
}
