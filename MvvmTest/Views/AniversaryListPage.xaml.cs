using System;
using System.Collections.Generic;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class AniversaryListPage : BaseContentPage
    {
        anniversaryViewModel _viewModel = null;
        public AniversaryListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new anniversaryViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
}
