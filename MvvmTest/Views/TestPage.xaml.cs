using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Device.BeginInvokeOnMainThread(() => 
            {
                App.Current.MainPage = new NavigationPage(new Views.MainPage());
            });
        }
    }
}
