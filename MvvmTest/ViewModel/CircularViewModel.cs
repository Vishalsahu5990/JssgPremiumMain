using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using MvvmTest.Services;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class CircularViewModel:BaseViewModel
    {
        private INavigation _navigation;
        public ObservableCollection<CircularModel> CircularList { get; set; }
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

        public CircularViewModel(INavigation navigation)
        {
            _navigation = navigation;
            PageTitle = "Circular";
            CircularList = new ObservableCollection<CircularModel>();
            GetCircular();

        }

            void GetCircular()
            {
                //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular");

                List<CircularModel> circularList = null;
                Task.Factory.StartNew(() =>
                {
                    ISyncServices syncService = new SyncServices();
                    circularList = syncService.GetCircular();

                }).ContinueWith((obj) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (circularList != null)
                        {
                            //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                            foreach (var item in circularList)
                        {
                            item.cirName= item.cirName.ToUpper();
                            CircularList.Add(item);  
                        }
                                
                            //CircularList = new ObservableCollection<CircularModel>(circularList);
                        }
                    });
                });
            }
    }
}
 