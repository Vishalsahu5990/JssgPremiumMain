using System;
using System.Collections.Generic;
using Xamarin.Forms;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using System.Windows.Input;
using MvvmTest.Helpers;
using System.Threading;
using System.Diagnostics;

namespace MvvmTest.Views
{
    public partial class LandingPage : BaseContentPage
    {
        private readonly TimeSpan timespan;
        private readonly Action callback;
        private CancellationTokenSource cancellation;

        int backPress = 0;
        public ICommand OpenMenuCommand { get; private set; }
        LandingViewModel _viewModel = null;
        public LandingPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LandingViewModel(this.Navigation);
           
        }

        public LandingPage(LoginModel model)
        {
            InitializeComponent();
            BindingContext = _viewModel = new LandingViewModel(this.Navigation);
            if(model!=null)
            {
               
            }
           
        }

        public async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GroupIntroductionPage()); 
        }

        public async void OfficeBearers_Tapped(object sender, System.EventArgs e)
        {
            await  Navigation.PushAsync(new OfficeBearersPage());
        }

        public async void Gallery_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }

        public async void Members_Tapped(object sender, System.EventArgs e)
        {
            if (!CommonHelpers.IsGuest)
            await Navigation.PushAsync(new MembersPage());
            else
            {
                var res =await DisplayAlert("Alert", "Please Login to access Members", "Login", "Cancel");
                if(res)
                {
                    CommonHelpers.IsGuest = false;
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                }}
        }

        public async void GroupInfo_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new CircularPage());

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


        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.cancellation = new CancellationTokenSource();
            MessagingCenter.Send<object>(this, "StopMoving");
            MessagingCenter.Subscribe<object>(this,"StartMoving",(obj) => StartAutoSlider());

        }
        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<object>(this, "StartMoving");
            Stop();
            base.OnDisappearing();
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
                    if (carouselSlider != null)
                    carouselSlider.Position = position;
                    Debug.WriteLine("Landing page slider running");
                    return true;
                });
            }
            catch (Exception ex)
            {

            }

        }

        protected override bool OnBackButtonPressed()
        {
            if (backPress == 0)
            {
                CommonHelpers.ShowToast("Press again to exit.");
                backPress++;
                return true;
            }
            else
            {
                backPress = 0;

                return false;
            }

        }

        public void Start()
        {
            CancellationTokenSource cts = this.cancellation; // safe copy
            Device.StartTimer(this.timespan,
                () => {
                    if (cts.IsCancellationRequested) return false;
                    this.callback.Invoke();
                    return false; // or true for periodic behavior
            });
        }

        public void Stop()
        {
            Interlocked.Exchange(ref this.cancellation, new CancellationTokenSource()).Cancel();
        }
    }
}
