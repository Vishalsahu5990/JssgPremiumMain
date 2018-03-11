using System;
namespace MvvmTest.ViewModel
{
    public class MembersDetailsViewModel:BaseViewModel
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
        public MembersDetailsViewModel()
        {
            PageTitle = "Member Detail";
        }
    }
}
