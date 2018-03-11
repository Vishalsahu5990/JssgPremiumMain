using Xamarin.Forms;
using System;
using MvvmTest.Helpers;
using MvvmTest.Views;
using MvvmTest.Services;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MvvmTest
{
    public partial class App : Application
    {
        public static bool IsVisible = false;
        public App(bool fromNotification=false,string memId="",string _type="")
        {
            InitializeComponent();
            //RegisterTypes();  
           // MainPage = new NavigationPage(new NotificationDetalPage("7","0"));
           
            if(!fromNotification)
            SetMainPage();  
            else
                MainPage = new NavigationPage(new Views.NotificationDetalPage(memId,_type));

            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged+= (sender, e) => 
            {
                if(e.IsConnected)
                {
                    CommonHelpers.ShowToast("Now you are connected to internet");  
                }
                else
                {
                    CommonHelpers.DismissLoader();
                    CommonHelpers.ShowToast("Please check your connection or try again later!");
                   
                }
            };

            //MainPage = new NavigationPage(new LoginPage());
        }
        protected override void OnStart()
        {
            base.OnStart();
            IsVisible = true;
           

        }
        protected override void OnSleep()
        {
            base.OnSleep();
            IsVisible = false;
            MessagingCenter.Send<object>(this, "StopMoving");
        }
        protected override void OnResume()
        {
            base.OnResume();
            MessagingCenter.Send<object>(this, "StartMovingAdd");
        }
        private void SetMainPage()
        {
           try
            {
                var userData = DependencyService.Get<IPersistStoreServices>().GetUserData();
                if (!ReferenceEquals(userData, null))
                {
                    if (string.IsNullOrEmpty(userData.id))
                        MainPage = new NavigationPage(new LoginPage());
                    else
                    {
                        if (Device.OS == TargetPlatform.iOS)
                        {

                            MainPage = new NavigationPage(new Views.MainPage());
                        }
                        else
                        {
                            CommonHelpers.IsAutologin = true;
                            //MainPage = new Views.MainPage();
                            MainPage = new NavigationPage(new Views.TestPage());
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                if (Device.OS == TargetPlatform.iOS)
                {

                    MainPage = new NavigationPage(new LoginPage());
                }
                else
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
            }
        }

        static void RegisterTypes()
        {
            // This can be replaced by any number of MVVM tools. It is done this way merely because this 
            // is not intended to be a demo of those tools.
            ViewFactory.Register<MvvmTestPage, ViewModel.ItemsViewModel>();
            ViewFactory.Register<Views.DetailsPage, ViewModel.DetailsViewModel>();
        }
    }
}
