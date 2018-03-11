using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using MvvmTest.Model;
using Xamarin.Forms;

namespace MvvmTest.UserControls
{
    public partial class AdvertiseView : Grid
    {
        private readonly TimeSpan timespan;
        private readonly Action callback;
        private CancellationTokenSource cancellation;

        ViewModel.AdvertiseViewModel _viewModel = null;

        public AdvertiseView()
        {
            InitializeComponent();
            BindingContext= _viewModel = new ViewModel.AdvertiseViewModel();
        }
        public async void SliderImage_Tapped(object sender, System.EventArgs e)
        {
            if (_viewModel.Images != null && _viewModel.Images.Count > 0)
            {
                var imageUrl = _viewModel.Images[carouselSlider.Position].sliderUrl;
                if (string.IsNullOrEmpty(imageUrl))
                    return;
                Device.BeginInvokeOnMainThread(() =>
                {
                    Device.OpenUri(new Uri(imageUrl));
                });
            }

        }
        private void StartAutoSlider()
        {
            try
            {
                CancellationTokenSource cts = this.cancellation; // safe copy
                Device.StartTimer(TimeSpan.FromSeconds(6), () =>
                {
                    if (cts.IsCancellationRequested) return false;

                    if (_viewModel.Images == null && _viewModel.Images.Count <= 0)
                        return false;
                    int max = _viewModel.Images.Count;
                    Random random = new Random();
                    var position = random.Next(0, max);
                    if(carouselSlider!=null)
                    carouselSlider.Position = position;
                    Debug.WriteLine("Advertise page slider running");
                    return true;
                });
            }
            catch (Exception ex)
            {

            }
           

        }
               
        public void Stop()
        {
            Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
        }
       protected override void OnAdded(Xamarin.Forms.View view)
        {
           base.OnAdded(view);
            this.cancellation = new CancellationTokenSource();
            StartAutoSlider();
            MessagingCenter.Subscribe<object>(this, "StartMovingAdd", (obj) => StartAutoSlider());
            MessagingCenter.Subscribe<object>(this, "StopMoving", (obj) => Stop());

        }
       protected override void OnRemoved(Xamarin.Forms.View view)
        {
            MessagingCenter.Unsubscribe<object>(this, "StartMovingAdd");
            MessagingCenter.Unsubscribe<object>(this, "StopMoving");
            Stop();
            base.OnRemoved(view);
        }

        //private void StartAutoSlider()
        //{
           

        //    Device.StartTimer(TimeSpan.FromSeconds(6), () =>
        //    {
        //        //var SlidePosition = carouselSlider.Position;
        //        //SlidePosition++;
        //        int max = _viewModel.Images.Count;
        //        Random random = new Random();
        //       var position= random.Next(0, max);
        //       carouselSlider.Position = position;
        //        return true;
        //    });

        //}
    }
}
