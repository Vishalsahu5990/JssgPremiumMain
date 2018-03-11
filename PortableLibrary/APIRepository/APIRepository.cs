using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Helper;
using DataAccessLayer.Models;
using DataAccessLayer.ServiceProvider;
using PortableLibrary.Interface;
using PortableLibrary.Models;

namespace DataAccessLayer.APIRepository
{
    public class APIRepository:IAPIRepository, IDisposable
    {
        /// <summary>
        /// The services.
        /// </summary>
        private APIServices _services;

        /// <summary>
        /// The parse.
        /// </summary>
        private Parse _parse;

        public APIRepository()
        {
            _services = new APIServices();
            _parse = new Parse();
        }

       

        /// <summary>
        /// Logins the authentication.
        /// </summary>
        /// <returns>The authentication.</returns>
        /// <param name="userId">User identifier.</param>
        /// <param name="password">Password.</param>
        async public Task<Tuple<bool, List<LoginModel>, ErrorResponse>> LoginAuthentication
                                                    (string userId, string password,string method)
        {
            var request = new
            {
                method=method,
                mobile = userId,
                password = password
            };

            var response = await _services.PostAsync(URL.Login, request);

            var deserialisedObject = _parse.ParseResponse<List<LoginModel>, ErrorResponse>(response);
            return deserialisedObject;
        }

       

        async public Task<Tuple<bool, List<CircularModel>, ErrorResponse>> GetCircular(string method)
        {
            var request = new
            {
                method = method,
               
            };

            var response = await _services.PostAsync(URL.Circular, request);

            var deserialisedObject = _parse.ParseResponse<List<CircularModel>, ErrorResponse>(response);
            return deserialisedObject;
        }

        public void Dispose()
        {

        }
    }
}
