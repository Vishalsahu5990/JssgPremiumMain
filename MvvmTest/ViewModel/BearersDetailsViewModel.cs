using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class BearersDetailsViewModel:BaseViewModel
    {
        private string _pageTitle;
        private string _name;
        private string _designation;
        private string _description;
        private string _bearPhoto;


        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Designation
        {
            get { return _designation; }
            set
            {
                _designation = value;
                OnPropertyChanged("Designation");
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
        public string BearPhoto
        {
            get { return _bearPhoto; }
            set
            {
                _bearPhoto = value;
                OnPropertyChanged("BearPhoto");
            }
        }
        public BearersDetailsViewModel(string bearerId)
        {
            PageTitle = "Office Bearer Detail";
            GetBearerDetails(bearerId);
        }
        void GetBearerDetails(string bearerId)
        {
           
            BearersModel bearerModel = null;
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                bearerModel = syncService.GetBearerDetails(bearerId);

            }).ContinueWith((obj) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (bearerModel != null)
                    {
                        Name = bearerModel.bearName;
                        Designation = bearerModel.bearDesination;
                        Description = bearerModel.bearDesc;
                        BearPhoto = bearerModel.bearPhoto;
                    }
                });
            });
        }
    }
}
