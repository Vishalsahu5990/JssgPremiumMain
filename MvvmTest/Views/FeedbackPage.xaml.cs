using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmTest.Helpers;
using MvvmTest.Services;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class FeedbackPage : BaseContentPage
    {
        FeedbackViewModel _viewModel = null;
        public FeedbackPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new FeedbackViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFeedback.Text))
            {
                SendFeedback();
            }
            else
                CommonHelpers.ShowAlert("Please fill comment befor continue!");
        }
        private void SendFeedback()
        {
            bool ret = false;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                ret = syncService.SendFeedback(txtSubject.Text,txtFeedback.Text);

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if(ret)
                    {
                        //App.Current.MainPage = new NavigationPage(new Views.MainPage());
                        App.Current.MainPage = new Views.MainPage();
                    }
                    else
                    {
                        CommonHelpers.ShowAlert("Failed to submit!"); 
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
