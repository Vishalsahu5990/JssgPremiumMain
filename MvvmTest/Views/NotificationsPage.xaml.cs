using System;
using System.Collections.Generic;
using Badge.Plugin;
using MvvmTest.Helpers;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class NotificationsPage : BaseContentPage
    {
        NotificationViewModel _viewModel = null;
        bool fromNotification = false;
        public NotificationsPage(bool isFromNotificationTap=false)
        {
            InitializeComponent();

            BindingContext = _viewModel = new NotificationViewModel();
            fromNotification = isFromNotificationTap;
            //CrossBadge.Current.ClearBadge();
        }
        public NotificationsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new NotificationViewModel();
            //CrossBadge.Current.ClearBadge();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemTapped+= (sender, e) => 
            {
                if (e.Item == null)
                    return;
                
                var model = e.Item as NotificationModel;
                if (!string.IsNullOrEmpty(model.memID) && !string.IsNullOrEmpty(model.type))
                    Navigation.PushAsync(new NotificationDetalPage(model.memID, model.type,model.name));
                else
                    ((ListView)sender).SelectedItem = null;               
            };
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //if(fromNotification)
            //{
            //    if (Device.OS == TargetPlatform.iOS)
            //    {

            //        App.Current.MainPage = new NavigationPage(new Views.MainPage());
            //    }
            //    else
            //    {
            //        CommonHelpers.IsAutologin = true;
            //        //MainPage = new Views.MainPage();
            //        App.Current.MainPage = new NavigationPage(new Views.TestPage());
            //    }
            //}
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            MessagingCenter.Send<object>(this, "OpenMenu");
        }
        void OnHomeClicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
}
