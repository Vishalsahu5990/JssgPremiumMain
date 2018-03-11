using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmTest.Helpers;
using MvvmTest.Services;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class ChangePasswordPage : BaseContentPage
    {
        ChangePasswordViewModel _viewModel = null;
        public ChangePasswordPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ChangePasswordViewModel();

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCurrentPassword.Text)
                && !string.IsNullOrEmpty(txtNewPassword.Text)
                && !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if(txtNewPassword.Text.Equals(txtConfirmPassword.Text)) 
                {
                    SendFeedback();
                }
                else
                {
                    CommonHelpers.ShowAlert("New password and confirm password did not matched.");  
                }
            }
            else
                CommonHelpers.ShowAlert("Incorrect details!");
        }

        private void SendFeedback()
        {
            List<ChangePasswordModel> model = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                model = syncService.ChangePassword(txtCurrentPassword.Text, txtNewPassword.Text);

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (!ReferenceEquals(model,null))
                    {
                        DisplayAlert("Alert", model[0].msg,"Ok");
                        //App.Current.MainPage = new NavigationPage(new Views.MainPage());
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    }
                    else
                    {
                       // CommonHelpers.ShowAlert(model[0].messages);
                    }
                });
            });
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
}
