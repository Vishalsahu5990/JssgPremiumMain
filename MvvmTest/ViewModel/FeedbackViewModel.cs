using System;
namespace MvvmTest.ViewModel
{
    public class FeedbackViewModel:BaseViewModel
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
        public FeedbackViewModel()
        {
            PageTitle = "Feedback/Suggestion";
        }
    }
}
