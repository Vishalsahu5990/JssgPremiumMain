using System;
namespace MvvmTest.ViewModel
{
    public class NotificationDetailViewModel:BaseViewModel
    {
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
        public NotificationDetailViewModel()
        {
            PageTitle = "Notification Detail";
        }
    }
}
