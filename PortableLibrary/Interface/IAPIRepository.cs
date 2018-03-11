using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using PortableLibrary.Models;

namespace PortableLibrary.Interface
{
    public interface IAPIRepository
    {
        Task<Tuple<bool, List<LoginModel>, ErrorResponse>> LoginAuthentication(string userId, string password, string method);
        Task<Tuple<bool, List<CircularModel>, ErrorResponse>> GetCircular(string method);
    
    }
}
