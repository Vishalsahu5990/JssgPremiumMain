using System;
using System.Collections.Generic;
using System.Linq;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class WeeklyUpdatesPage : BaseContentPage
    {
        WeeklyUpdatesViewModel _viewModel = null;
        public WeeklyUpdatesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new WeeklyUpdatesViewModel();


        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
}
