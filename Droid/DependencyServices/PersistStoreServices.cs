using System;
using Android.Content;
using PortableLibrary.Models;
using MvvmTest.Services;
using Xamarin.Forms;
using MvvmTest.Droid.DependencyServices;

[assembly: Dependency(typeof(PersistStoreServices))]
namespace MvvmTest.Droid.DependencyServices
{
    public class PersistStoreServices:IPersistStoreServices
    {
        public PersistStoreServices()
        {
        }

        public void DeleteUserData()        
        {
            var prefs = Android.App.Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            var storage = prefs.Edit(); 
            storage.PutString("id", "");
            storage.PutString("mobile", "");
            storage.PutString("name", "");
            storage.PutString("email", "");
            storage.Commit();
        }

        public LoginModel GetUserData()
        {
            var storage = Android.App.Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            LoginModel loginModel = new LoginModel();
            loginModel.id = storage.GetString("id", "");
            loginModel.mobile = storage.GetString("mobile", "");
            loginModel.name = storage.GetString("name", "");
            loginModel.email = storage.GetString("email", "");
            return loginModel;
        }

        public void SaveUserData(LoginModel loginModel)
        {
            var prefs = Android.App.Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);
            var storage = prefs.Edit();
            storage.PutString("id", loginModel.id.ToString());
            storage.PutString("mobile", loginModel.mobile);
            storage.PutString("name", loginModel.name);
            storage.PutString("email", loginModel.email);
            storage.Commit();
        }
    }
}
