using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmTest.Services;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class MemberDetailsPage : BaseContentPage
    {
        MembersDetailsViewModel _viewModel = null;
        public MemberDetailsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MembersDetailsViewModel();
        }
        public MemberDetailsPage(string memberId)
        {
            InitializeComponent();
            BindingContext = _viewModel = new MembersDetailsViewModel();
            GetCircular(memberId);
        }
        void GetCircular(string memberId)
        {
            //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular");

            List<MembersDetailsModel> circularList = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                circularList = syncService.GetMemberDetails(memberId);

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (circularList != null)
                    {
                        var memberDetails = circularList[0];
                        lblMemberName.Text = memberDetails.memName;
                        lblmarriageAnniversary.Text = memberDetails.merrageAnyver;
                        lblHusbandDob.Text = memberDetails.dob_Husband;
                        lblWifeDob.Text = memberDetails.dob_Wife;
                        lblOccupation.Text = memberDetails.business;
                        lblOfficeAddress.Text = memberDetails.businessAddr;
                        lblResidentialAddress.Text = memberDetails.residenceAddr;
                        lblHusbandMobileNumber.Text = memberDetails.memMobile;
                        lblWifeMobileNumber.Text = memberDetails.wifeContact;
                        lblResidenceContactNo.Text = memberDetails.residenceNum;
                          lblEmail.Text = memberDetails.email;
                        lblWebsite.Text = memberDetails.website;
                        lblBGHusband.Text = memberDetails.memBG;
                        lblBGWife.Text = memberDetails.wifeBG;
                        lblOfficeContactNo.Text= memberDetails.businessNum;

                        if (string.IsNullOrEmpty(memberDetails.memPhoto))
                            imgMemberImage.Source = "demo";
                        else
                        imgMemberImage.Source = memberDetails.memPhoto;
                        if(!ReferenceEquals(memberDetails.child,null))
                        listview.FlowItemsSource = memberDetails.child;
                        //lblChildrenName.Text = memberDetails.;
                        //lblChildrenDob.Text = memberDetails.merrageAnyver;
                        //lblChildrenClass.Text = memberDetails.merrageAnyver;

                    }
                });
            });
        }
    }
}
