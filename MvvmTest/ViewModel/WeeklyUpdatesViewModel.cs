using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class WeeklyUpdatesViewModel:BaseViewModel
    {
        private string _pageTitle;
        public ObservableCollection<WeeklyUpdatesModel> UpdatesList { get; set; }

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        public WeeklyUpdatesViewModel()
        {
            PageTitle = "Updates";
            UpdatesList = new ObservableCollection<WeeklyUpdatesModel>();
            GetBearers();
        }
        private void GetBearers()
        {
            List<WeeklyUpdatesModel> bearersList = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                bearersList = syncService.GetWeeklyUpdates();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (bearersList != null)
                        foreach (var item in bearersList)
                        {
                            var convertedTime = Convert.ToDateTime(item.added_on);
                            var time = convertedTime.ToString("D") + " | " + convertedTime.DayOfWeek;
                            item.added_on = time;
                        UpdatesList.Add(item);
                        }


                });
            });
        }
    }
}
