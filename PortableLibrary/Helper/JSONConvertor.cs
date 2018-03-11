using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DataAccessLayer.Helper
{
    public class JSONConvertor
    {
        /// <summary>
        /// Deserializes the response into desired object
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="obj">Object.</param>
        /// <param name="response">Response.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static T DeserializeResponse<T>(HttpResponseMessage response)
        {
            
            var content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(content);
        }

        /// <summary>
        /// Deserializes the response into object
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="response">Response.</param>
        public static string DeserializeResponse(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject(content).ToString();
        }

        /// <summary>
        /// Gets the Json Object.
        /// </summary>
        /// <returns>The JObject.</returns>
        /// <param name="response">Response.</param>
        public static JObject GetJObject(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;

            return Newtonsoft.Json.Linq.JObject.Parse(json);
        }
       
    }
}
