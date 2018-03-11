using System;
using Foundation;
using MvvmTest.iOS.DependencyServices;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(PersistStoreServices))]
namespace MvvmTest.iOS.DependencyServices
{
    public class PersistStoreServices: IPersistStoreServices
    {
        string ID = "id";
        string MOBILE = "mobile";
        string NAME = "name";
        string EMAIL = "email";
        public PersistStoreServices()
        {
        }

        public void DeleteUserData()
        {
            NSUserDefaults.StandardUserDefaults.SetString("", ID);
            NSUserDefaults.StandardUserDefaults.SetString("", MOBILE);
            NSUserDefaults.StandardUserDefaults.SetString("", NAME);
            NSUserDefaults.StandardUserDefaults.SetString("", EMAIL);
        }

        public LoginModel GetUserData()
        {
            var model=new LoginModel();
            model.id=  NSUserDefaults.StandardUserDefaults.StringForKey(ID);
            model.mobile =  NSUserDefaults.StandardUserDefaults.StringForKey( MOBILE);
            model.name =  NSUserDefaults.StandardUserDefaults.StringForKey( NAME);
            model.email =  NSUserDefaults.StandardUserDefaults.StringForKey( EMAIL);
            return model;
        }

        public void SaveUserData(LoginModel loginModel)
        {
            NSUserDefaults.StandardUserDefaults.SetString(loginModel.id, ID);
            NSUserDefaults.StandardUserDefaults.SetString(loginModel.mobile, MOBILE);
            NSUserDefaults.StandardUserDefaults.SetString(loginModel.name, NAME);
            NSUserDefaults.StandardUserDefaults.SetString(loginModel.email, EMAIL);

        }
    }
}
