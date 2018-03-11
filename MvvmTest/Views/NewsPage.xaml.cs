using System;
using System.Collections.Generic;
using System.Linq;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class NewsPage : BaseContentPage
    {
        NewsViewModel _viewModel = null;
        public NewsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new NewsViewModel();
           
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
}
