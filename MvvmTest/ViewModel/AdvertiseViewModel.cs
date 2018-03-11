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
    public class AdvertiseViewModel:BaseViewModel
    {
        public ObservableCollection<SliderModel> Images { get; set; }
        public AdvertiseViewModel()
        {
            Images = new ObservableCollection<SliderModel>();
            BindImages();
        }
        private void BindImages()
        {
            List<SliderModel> memberList = null;
            Images.Clear();
            Task.Factory.StartNew(() =>
            {
                ISyncServices syncService = new SyncServices();
                memberList = syncService.GetFooterSliderImages();

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
                        //CircularList = new ObservableCollection<CircularModel>(circularList);
                    }
                });
            });
        }
    }
}
