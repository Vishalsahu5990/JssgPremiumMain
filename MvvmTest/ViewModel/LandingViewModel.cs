using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MvvmTest.Model;
using MvvmTest.Services;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class LandingViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public ObservableCollection<SliderModel> Images { get; set; }
        private string _pageTitle;
        private string _rightIcon;
        private string _leftIcon;
        public string PageTitle
        {
            get { return _pageTitle; }
            set
            {
                _pageTitle = value;
                OnPropertyChanged("PageTitle");
            }
        }

        public string LeftIcon
        {
            get { return _leftIcon; }
            set
            {
                _leftIcon = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public string RightIcon
        {
            get { return _rightIcon; }
            set
            {
                _rightIcon = value;
                OnPropertyChanged("PageTitle");
            }
        }
        public LandingViewModel(INavigation navigation)
        {
            _navigation = navigation;

            BindImages();
            LeftIcon = "menu";
            RightIcon = "home";
            PageTitle = "JSSG Premium Main";
            Images = new ObservableCollection<SliderModel>();
        }
        public LandingViewModel()
        {
           
            BindImages();
            LeftIcon = "menu";
            RightIcon = "home";
            PageTitle = "JSSG Premium Main";
            Images = new ObservableCollection<SliderModel>();
        }

        public void BindImages()
        {
           try
            {
                List<SliderModel> memberList = null;


                Task.Factory.StartNew(() =>
                {
                    ISyncServices syncService = new SyncServices();
                    memberList = syncService.GetSliderImages();

                }).ContinueWith((obj) =>
                {

                    Device.BeginInvokeOnMainThread(() => 
                    {
                        if (memberList != null)
                        {
                            //MvvmTest.Helpers.CommonHelpers.ShowAlert("circular success");
                            foreach (var item in memberList)
                                Images.Add(item);

                            MessagingCenter.Send<object>(this, "StartMoving");
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
