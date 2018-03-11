using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class UsefulInfoViewModel:BaseViewModel
    {
        private bool _jainTirth;
        private bool _impNumber;
        private string _jainTabColor;
        private string _impTabColor;
        private string _jainTextColor;
        private string _impTextColor;
        public ObservableCollection<TirthModel> TirthList { get; set; }
        public ObservableCollection<ImportantModel> ImpList { get; set; }

         ICommand _jainTirthTapped;
         ICommand _impNumberTapped;

        public ICommand JainTirthTapped
        {
            get { return _jainTirthTapped; }
        }
        public ICommand ImpNumberTapped
        {
            get { return _impNumberTapped; }
        }
       
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
        public bool JainTirth
        {
            get { return _jainTirth; }
            set
            {
                _jainTirth = value;
                OnPropertyChanged("JainTirth");
            }
        }
        public bool ImpNumber
        {
            get { return _impNumber; }
            set
            {
                _impNumber = value;
                OnPropertyChanged("ImpNumber");
            }
        }
        public string JainTabColor
        {
            get { return _jainTabColor; }
            set
            {
                _jainTabColor = value;
                OnPropertyChanged("JainTabColor");
            }
        }
        public string ImpTabColor
        {
            get { return _impTabColor; }
            set
            {
                _impTabColor = value;
                OnPropertyChanged("ImpTabColor");
            }
        }

        public string JainTextColor
        {
            get { return _jainTextColor; }
            set
            {
                _jainTextColor = value;
                OnPropertyChanged("JainTextColor");
            }
        }
        public string ImpTextColor
        {
            get { return _impTextColor; }
            set
            {
                _impTextColor = value;
                OnPropertyChanged("ImpTextColor");
            }
        }
        public UsefulInfoViewModel()
        {
           
            PageTitle = "Useful Information";
            TirthList = new ObservableCollection<TirthModel>();
            ImpList = new ObservableCollection<ImportantModel>();
        }

        public void OnJainTirthTapped()
        {
            JainTirth = true;
            ImpNumber = false;

            JainTabColor = "#ffffff";
            ImpTabColor = "#DBDBDB";

            JainTextColor = "#23A193";
            ImpTextColor = "#B4B4B4";


        }

        public void OnImpNumberTapped()
        {
            JainTirth = false;
            ImpNumber = true;

            ImpTabColor = "#ffffff";
            JainTabColor = "#DBDBDB";

            ImpTextColor = "#23A193";
            JainTextColor = "#B4B4B4";
        }
        public void GetTirths()
        {
            List<TirthModel> memberList = null;
            TirthList.Clear();
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetjainTirth();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (memberList != null)
                    {
                        //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                        foreach (var item in memberList)
                            TirthList.Add(item);
                        //CircularList = new ObservableCollection<CircularModel>(circularList);
                    }
                });
            });
        }
        public void GetImpNumbers()
        {
            List<ImportantModel> memberList = null;
            ImpList.Clear();
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetImpNumbers();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (memberList != null)
                    {
                        //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                        foreach (var item in memberList)
                            ImpList.Add(item);
                        //CircularList = new ObservableCollection<CircularModel>(circularList);
                    }
                });
            });
        }
    }
}
