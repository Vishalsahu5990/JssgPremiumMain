using System;
using Acr.UserDialogs;
using MvvmTest.Views;
namespace MvvmTest.Helpers
{
    public static class CommonHelpers
    {
        /// <summary>
        /// Shows the loader.
        /// </summary>
         public static MainPage currentContext = null;
        public static bool IsGuest = false;
        public static bool IsAutologin = false;
        public static string DeviceToken = string.Empty;
        public static string UserId = string.Empty;
        public static void ShowLoader()
        {
            UserDialogs.Instance.ShowLoading(); 
        }

        /// <summary>
        /// Dismisses the loader.
        /// </summary>
        public static void DismissLoader()
        {
            UserDialogs.Instance.HideLoading();
        }

        public static void ShowAlert(string message)
        {
            UserDialogs.Instance.ShowError(message);
        }
        public static void ShowToast(string message)
        {
            UserDialogs.Instance.Toast(message);
        }
        public static string TimeAgo(this DateTime dateTime)
        {
            string result = string.Empty;
            var timeSpan = DateTime.Now.Subtract(dateTime);

            if (timeSpan <= TimeSpan.FromSeconds(60))
            {
                result = string.Format("{0} seconds ago", timeSpan.Seconds);
            }
            else if (timeSpan <= TimeSpan.FromMinutes(60))
            {
                result = timeSpan.Minutes > 1 ?
                    String.Format("about {0} minutes ago", timeSpan.Minutes) :
                    "about a minute ago";
            }
            else if (timeSpan <= TimeSpan.FromHours(24))
            {
                result = timeSpan.Hours > 1 ?
                    String.Format("about {0} hours ago", timeSpan.Hours) :
                    "about an hour ago";
            }
            else if (timeSpan <= TimeSpan.FromDays(30))
            {
                result = timeSpan.Days > 1 ?
                    String.Format("about {0} days ago", timeSpan.Days) :
                    "yesterday";
            }
            else if (timeSpan <= TimeSpan.FromDays(365))
            {
                result = timeSpan.Days > 30 ?
                    String.Format("about {0} months ago", timeSpan.Days / 30) :
                    "about a month ago";
            }
            else
            {
                result = timeSpan.Days > 365 ?
                    String.Format("about {0} years ago", timeSpan.Days / 365) :
                    "about a year ago";
            }

            return result;
        }
    }
}
