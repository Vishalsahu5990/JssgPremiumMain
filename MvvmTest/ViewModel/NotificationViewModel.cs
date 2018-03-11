using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmTest.Helpers;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class NotificationViewModel:BaseViewModel
    {
        private string _pageTitle;
        public ObservableCollection<NotificationModel> NotificationList { get; set; }
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        public NotificationViewModel()
        {
            PageTitle = "Notifications";
            NotificationList = new ObservableCollection<NotificationModel>();
            GetBearers();
        }

        private void GetBearers()
        {
           try
            {
                List<NotificationModel> bearersList = null;
                Task.Factory.StartNew(() =>
                {
                    ISyncServices syncService = new SyncServices();
                    bearersList = syncService.GetAllNotification();

                }).ContinueWith((obj) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        if (bearersList != null)
                        {
                            bearersList = bearersList.OrderByDescending(d => DateTime.Parse(d.addedOn).Date)
                                                  .Select(x => x).ToList();

                            foreach (var item in bearersList)
                            {
                                if (!string.IsNullOrEmpty(item.addedOn))
                                    item.addedOn = CommonHelpers.TimeAgo(DateTime.Parse(item.addedOn));
                                NotificationList.Add(item);
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
