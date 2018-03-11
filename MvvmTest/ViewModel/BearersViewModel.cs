using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;
namespace MvvmTest.ViewModel
{
    public class BearersViewModel:BaseViewModel
    {
        private INavigation _navigation;
        public ObservableCollection<BearersModel> BearersList { get; set; }
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
        public BearersViewModel(INavigation navigation)
        {
            _navigation = navigation;
            PageTitle = "Office Bearers";
            BearersList = new ObservableCollection<BearersModel>();
            GetBearers();
        }

        private void GetBearers()
        {
            List<BearersModel> bearersList = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                bearersList = syncService.GetBearers();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (bearersList != null)
                        foreach (var item in bearersList)
                            BearersList.Add(item);
                        

                });
            });
        }
    }
}
