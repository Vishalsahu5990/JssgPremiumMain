using System;
using System.Collections.Generic;
using MvvmTest.Helpers;
using MvvmTest.Model;
using MvvmTest.Services;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }

        ListView listView;  
        public MasterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
            var masterPageItems = new List<MasterPageItemModel>();
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "News",
                IconSource = "news.png",
                TargetType = typeof(NewsPage),

            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Anniversary List",
                IconSource = "anniversary.png",
                TargetType = typeof(AniversaryListPage)
            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Birthday List",
                IconSource = "birthday.png",
                TargetType = typeof(BirthDayListPage)
            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Blood Group List",
                IconSource = "blood_group_list.png",
                TargetType = typeof(BloodGroupListPage)
            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Useful Information",
                IconSource = "useful_info.png",
                TargetType = typeof(UsefulInformationPage)
            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Updates",
                IconSource = "weekly_update.png",
                TargetType = typeof(WeeklyUpdatesPage)
            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Panchang & Choghadiya",
                IconSource = "panchang.png",
                TargetType = typeof(PanchangAndChoghadiyaPage)
            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Feedback",
                IconSource = "feedback.png",
                TargetType = typeof(FeedbackPage)
            });
            if(!CommonHelpers.IsGuest)
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Change Password",
                IconSource = "change_pwd.png",
                TargetType = typeof(ChangePasswordPage)
            });
            masterPageItems.Add(new MasterPageItemModel
            {
                Title = "Notifications",
                IconSource = "notification_icon.png",
                TargetType = typeof(NotificationsPage)
            });

            listview.ItemsSource = masterPageItems;

           var userData= DependencyService.Get<IPersistStoreServices>().GetUserData();
            if (userData != null)
            {
                lblUserName.Text = userData.name;
            }
            if (CommonHelpers.IsGuest)
                lblUserName.Text = "Welcome Guest";
        }

        void Logout_Tapped(object sender, System.EventArgs e)
        {
            CommonHelpers.IsGuest = false;
            DependencyService.Get<IPersistStoreServices>().DeleteUserData();
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}

