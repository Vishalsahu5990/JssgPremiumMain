using System;
using System.Net.Http;

namespace DataAccessLayer.Helper
{
    public class Parse
    {
        /// <summary>
        /// Parses the response into desired object
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="response">Response.</param>
        /// <typeparam name="T">The 1st It will return whether request is success or not.</typeparam>
        /// <typeparam name="K">The 2nd It will return the deserialisedObject if request is sueessful.</typeparam>
        /// <typeparam name="E">The 3rd It will return error .</typeparam>
        public Tuple<bool, T, E> ParseResponse<T, E>(HttpResponseMessage response)
                                                                where T : new()
                                                                where E : new()
        {
            bool isSuccess;
            T responseObject;
            E error;

            isSuccess = response.IsSuccessStatusCode;

            responseObject = (isSuccess) ? JSONConvertor.DeserializeResponse<T>(response) : new T();
            error = (isSuccess) ? new E() : JSONConvertor.DeserializeResponse<E>(response);

            return Tuple.Create(isSuccess, responseObject, error);
        }

        /// <summary>
        /// Parses the response and return the object with the json key if response is successful
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="response">Response.</param>
        /// <param name="jsonKey">Json key.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <typeparam name="E">The 2nd type parameter.</typeparam>
        public Tuple<bool, T, E> ParseResponse<T, E>(HttpResponseMessage response, string jsonKey)
                                                                            where T : new()
                                                                            where E : new()
        {
            bool isSuccess;
            T responseObject;
            E error;

            isSuccess = response.IsSuccessStatusCode;

            var json = JSONConvertor.GetJObject(response);

            responseObject = (isSuccess && json != null) ? json[jsonKey].ToObject<T>() : new T();
            error = (isSuccess) ? new E() : JSONConvertor.DeserializeResponse<E>(response);

            return Tuple.Create(isSuccess, responseObject, error);
        }

        /// <summary>
        /// Parses the response.
        /// </summary>
        /// <returns>The response.</returns>
        /// <param name="response">Response.</param>
        public string ParseResponse(HttpResponseMessage response)
        {
            var responseObject = JSONConvertor.DeserializeResponse(response);

            return responseObject;
        }
    }
}
