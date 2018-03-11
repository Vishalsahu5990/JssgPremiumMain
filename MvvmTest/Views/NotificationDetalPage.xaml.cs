using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MvvmTest.Helpers;
using MvvmTest.Services;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class NotificationDetalPage : BaseContentPage
    {
        string _type = "";
        string _memId = "";
        string _name = "";
        NotificationDetailViewModel _viewModel = null;
        public NotificationDetalPage(string memId,string type,string name=null)
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            _type = type;
            _memId = memId;
            _name = name;
            Debug.WriteLine("#######################++++"+_memId);
            BindingContext = _viewModel = new NotificationDetailViewModel();
            GetCircular();
        }
        void GetCircular()
        {
            //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular");

            List<MembersDetailsModel> circularList = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                circularList = syncService.GetMemberDetails(_memId);

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    
                    if (circularList != null)
                    {
                       
                        var memberDetails = circularList[0];
                        if (_name != null)
                        {
                            var array = _name.Split(new[] { "has" }, StringSplitOptions.None);
                            var name = array[0];

                            if (_type.Equals("0"))
                            {
                                lblName.Text = "HAPPY ANNIVERSARY " + name;
                            }
                            else
                            {
                                lblName.Text = "HAPPY BIRTHDAY " + name;
                            }
                        }
                        else
                        {
                            if (_type.Equals("0"))
                            {
                                lblName.Text = "HAPPY ANNIVERSARY " + memberDetails.memName;
                            }
                            else
                            {
                                lblName.Text = "HAPPY BIRTHDAY " + memberDetails.memName;
                            }  
                        }

                       
                        lblMobile.Text = memberDetails.memMobile;

                       

                        if (string.IsNullOrEmpty(memberDetails.memPhoto))
                            imgMember.Source = "demo";
                        else
                            imgMember.Source = memberDetails.memPhoto;

                       

                    }
                });
            });
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        protected override void OnDisappearing()
        {
           
              base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
            return true;
        }
    }
}
