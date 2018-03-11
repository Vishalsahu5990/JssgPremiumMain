using System;
using System.Collections.Generic;
using MvvmTest.Helpers;
using MvvmTest.Services;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class LoginPage : BaseContentPage
    {
        LoginViewModel _viewModel = null;
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new LoginViewModel(this.Navigation);
            //txtMobileNumber.Text = "7415819881";
            //txtPassword.Text = "12345678";
        }


        void Handle_Tapped(object sender, System.EventArgs e)
        {
            //guest user tapped
            CommonHelpers.IsGuest = true;
            App.Current.MainPage = new NavigationPage(new Views.MainPage(true));
        }


        async void Handle_Tapped1(object sender, System.EventArgs e)
        {
            //forgot password
            //if(!string.IsNullOrEmpty(_viewModel.MobileNumber))  
            //{
            //    var res = await DisplayAlert("Alert", "You will receive a notification by pressing continue", "Continue", "Cancel");
            //    if (res)
            //    {
            //        Device.BeginInvokeOnMainThread(async () => 
            //        {
            //            ISyncServices service = new SyncServices();
            //            var ret = service.ForgotPassword(txtMobileNumber.Text); 
            //            //if(ret)
            //               // await DisplayAlert("Alert", "You will receive a notification by pressing continue", "Ok");

            //        });
            //    }
            
            //}
            //   else
            //{
            //    DisplayAlert("Alert","Please enter your mobile number to reset password","Ok");
            //}
        }
    }
}
