using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class GalleryDetailsViewModel:BaseViewModel
    {
        private string _pageTitle;
        private string _meetingName;
        private string _venu;
        public ObservableCollection<GalleryModel> MemberList { get; set; }
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public string MeetingName
        {
            get { return _meetingName; }
            set
            {
                _meetingName = value;
                OnPropertyChanged("MeetingName");
            }
        }
        public string Venu
        {
            get { return _venu; }
            set
            {
                _venu = value;
                OnPropertyChanged("Venu");
            }
        }
        public GalleryDetailsViewModel(string galleryId, string meetingName,string venu)
        {
            PageTitle = "Gallery";
            MeetingName = meetingName;
            Venu = venu;
            MemberList = new ObservableCollection<GalleryModel>();
            GetMembers(galleryId);
        }
        private void GetMembers(string galleryId)
        {
            List<GalleryModel> memberList = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetGalleryDetails(galleryId);

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (memberList != null)
                    {
                        //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                        foreach (var item in memberList)
                        {
                            if (string.IsNullOrEmpty(item.galleryPhoto))
                                item.galleryPhoto = "demo";
                            MemberList.Add(item);
                        }
                        //CircularList = new ObservableCollection<CircularModel>(circularList);
                    }
                });
            });
        }
    }
}
