using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmTest.Resx;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class HomeViewModel:BaseViewModel
    {
        INavigation _navigation;
        public ObservableCollection<GalleryModel> GalleryList { get; set; }

        private string _pageTitle;

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        public HomeViewModel(INavigation navigation)
        {
            _navigation = navigation;
            PageTitle= AppResources.ResourceManager.GetString("gallery");
            GalleryList = new ObservableCollection<GalleryModel>();
            GetBearers();
        }
        private void GetBearers()
        {
            List<GalleryModel> bearersList = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                bearersList = syncService.GetGallery();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (bearersList != null)
                        foreach (var item in bearersList)
                        {
                            if (string.IsNullOrEmpty(item.galleryPhoto))
                                item.galleryPhoto = "demo";
                           

                            GalleryList.Add(item);
                        }


                });
            });
        }
    }
}
