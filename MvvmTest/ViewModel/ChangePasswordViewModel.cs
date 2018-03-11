using System;
namespace MvvmTest.ViewModel
{
    public class ChangePasswordViewModel:BaseViewModel
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
        public ChangePasswordViewModel()
        {
            PageTitle = "Change Password";
        }
    }
}
