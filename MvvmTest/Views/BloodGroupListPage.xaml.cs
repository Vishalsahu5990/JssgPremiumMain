using System;
using System.Collections.Generic;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class BloodGroupListPage : BaseContentPage
    {
        BloodGroupViewModel _viewModel = null;
        public BloodGroupListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BloodGroupViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
}
