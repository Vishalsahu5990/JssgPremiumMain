using System;
using PortableLibrary.Models;
namespace MvvmTest.Services
{
    public interface IPersistStoreServices
    {
        void SaveUserData(LoginModel loginModel);
        void DeleteUserData();
        LoginModel GetUserData();
    }
}
