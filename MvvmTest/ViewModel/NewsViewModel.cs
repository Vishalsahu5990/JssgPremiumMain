using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class NewsViewModel: BaseViewModel
    {
        private string _pageTitle;
        public ObservableCollection<NewsModel> NewsList { get; set; }


        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public NewsViewModel()
        {
            PageTitle = "News";
            NewsList = new ObservableCollection<NewsModel>();
            GetBearers();
        }
        private void GetBearers()
        {
           try
            {
                List<NewsModel> bearersList = null;
                Task.Factory.StartNew(() =>
                {
                    ISyncServices syncService = new SyncServices();
                    bearersList = syncService.GetNews();

                }).ContinueWith((obj) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (bearersList != null && bearersList.Count > 0)
                        {
                            var sorted = bearersList.OrderByDescending(d => d.added_on)
                                         .Select(x => x).ToList();
                            foreach (var item in sorted)
                            {
                                var convertedTime = DateTime.ParseExact(item.added_on, "dd-MM-yyyy", null);
                                var time = convertedTime.ToString("D") + " | " + convertedTime.DayOfWeek;
                                item.added_on = time;
                                NewsList.Add(item);
                            }

                        }
                    });
                });
            }
            catch (Exception ex)
            {

            }
        }
    }
}
