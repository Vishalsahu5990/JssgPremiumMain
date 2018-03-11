using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class GroupIntroductionViewModel:BaseViewModel
    {
        /// <summary>
        /// The page title.
        /// </summary>
        private string _pageTitle;
        /// <summary>
        /// The description.
        /// </summary>
        private string _description;

        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }
        public GroupIntroductionViewModel()
        {
            PageTitle = "Group Introduction";

            GetGroupIntro();
        }

        private void GetGroupIntro()
        {
            List<GroupIntroModel> groupIntroModel = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                groupIntroModel = syncService.GetGroupIntro();

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (groupIntroModel != null)
                    {
                        Description = groupIntroModel[0].groupDesc;

                    }
                });
            });
        }
    }
}
