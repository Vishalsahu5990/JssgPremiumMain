using System;
using System.Collections.Generic;
using System.Linq;
using MvvmTest.Helpers;
using MvvmTest.Model;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class MainPage : MasterDetailPage
    {
        int backPress = 0;
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            masterpage.ListView.ItemSelected += OnItemSelected;
            MessagingCenter.Subscribe<object>(this, "OpenMenu", HandleAction);


        }
        public MainPage(bool guest)
        {
            InitializeComponent();
            CommonHelpers.IsGuest = guest;
            NavigationPage.SetHasNavigationBar(this, false);

            masterpage.ListView.ItemSelected += OnItemSelected;
            MessagingCenter.Subscribe<object>(this, "OpenMenu", HandleAction);
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as MasterPageItemModel;
            if (item == null)
                return;

            if (item.TargetType == typeof(AniversaryListPage)
               || item.TargetType == typeof(BirthDayListPage) ||
               item.TargetType == typeof(WeeklyUpdatesPage) ||
               item.TargetType == typeof(FeedbackPage) ||
               item.TargetType == typeof(ChangePasswordPage))
            {
                if (CommonHelpers.IsGuest)
                {
                    IsPresented = false;

                    var res = await DisplayAlert("Alert", "Please Login to access", "Login", "Cancel");
                    if (res)
                    {
                        CommonHelpers.IsGuest = false;
                        App.Current.MainPage = new NavigationPage(new LoginPage());
                    }
                }
                else
                {
                    if (item != null)
                    {
                        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                        masterpage.ListView.SelectedItem = null;
                        IsPresented = false;
                    }
                }

            }
            else
            {
                if (item != null)
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    masterpage.ListView.SelectedItem = null;
                    IsPresented = false;
                }
            }

        }

        void HandleAction(object obj)
        {
            this.IsPresented = true;
        }
        protected override void OnDisappearing()
        {
            //MessagingCenter.Unsubscribe<object>(this, "OpenMenu");
            base.OnDisappearing();
        }
       

        public bool DoBack
        {
            get
            {
                NavigationPage mainPage = App.Current.MainPage as NavigationPage;
                if (mainPage != null)
                {
                    return Navigation.NavigationStack.Count > 0;
                }
                return true;
            }
        }
    }
}
