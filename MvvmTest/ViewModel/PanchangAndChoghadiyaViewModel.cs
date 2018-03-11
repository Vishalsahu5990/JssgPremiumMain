using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class PanchangAndChoghadiyaViewModel:BaseViewModel
    {
        private string _pageTitle;
        public ObservableCollection<PanchangModel> PanchangList { get; set; }
        public ObservableCollection<ChokadiyaModel> ChoghadiyaList { get; set; }
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public PanchangAndChoghadiyaViewModel()
        {
            PageTitle = "Jain Panchang & Choghadiya";
            PanchangList = new ObservableCollection<PanchangModel>();
            ChoghadiyaList = new ObservableCollection<ChokadiyaModel>();
        }

        public void GetPanchang()
        {
            List<PanchangModel> memberList = null;
            PanchangList.Clear();
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetPanchang();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (memberList != null)
                    {
                        //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                        foreach (var item in memberList)
                            PanchangList.Add(item);
                        //CircularList = new ObservableCollection<CircularModel>(circularList);
                    }
                });
            });
        }

        public void GetChoghadiya()
        {
            List<ChokadiyaModel> memberList = null;
            ChoghadiyaList.Clear();
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetChoghadiya();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (memberList != null)
                    {
                        //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                        foreach (var item in memberList)
                            ChoghadiyaList.Add(item);
                        //CircularList = new ObservableCollection<CircularModel>(circularList);
                    }
                });
            });
        }
    }
}
