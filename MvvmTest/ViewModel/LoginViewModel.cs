using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmTest.Helpers;
using MvvmTest.Resx;
using MvvmTest.Services;
using MvvmTest.Views;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }
        public ICommand ForgotPasswordCommand { get; set; }
        public ICommand GuestUserCommand { get; set; }

        private string _mobileNumber;
        private string _password;

        private INavigation _navigation;
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                _mobileNumber = value;
                OnPropertyChanged("MobileNumber");
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            LoginCommand = new Command(LoginProcess);
           
        }

        /// <summary>
        /// Logins the process.
        /// </summary>
        public void LoginProcess()
        {
            //MobileNumber = "9770789763";
            //Password = "mishra";

            if (IsValid())
            {
                List<LoginModel> loginModel = null;
                Task.Factory.StartNew(() =>
                {
                    ISyncServices syncService = new SyncServices();
                    loginModel = syncService.ValidateUser(MobileNumber, Password);

                }).ContinueWith((obj) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (loginModel != null && loginModel.Count>0)
                        {
                            //saving to local
                            DependencyService.Get<IPersistStoreServices>().SaveUserData(loginModel[0]);
                            CommonHelpers.UserId = loginModel[0].mobile;
                            App.Current.MainPage = new NavigationPage(new Views.MainPage());
                          
                        }
                            
                    else
                        CommonHelpers.ShowAlert(AppResources.ResourceManager.GetString("validationError"));
   
                    });
                });

            }
            else
                CommonHelpers.ShowAlert(AppResources.ResourceManager.GetString("validationError"));


            /// <summary>
            /// checks for
            /// Is the credentials are valid.
            /// </summary>
            /// <returns><c>true</c>, if valid was ised, <c>false</c> otherwise.</returns>
            bool IsValid()
            {
                bool isValid = true;
                if (string.IsNullOrEmpty(MobileNumber))
                {
                    isValid = false;
                }
                else
                {
                    if (MobileNumber.Length != 10)
                    {
                        CommonHelpers.ShowAlert(AppResources.ResourceManager.GetString("invalidMobileNoError"));
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                    }
                }
                if (string.IsNullOrEmpty(Password))
                {
                    isValid = false;
                }

                return isValid;
            }

        }
    }
}
