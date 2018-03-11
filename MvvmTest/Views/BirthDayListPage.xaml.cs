using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class BirthDayListPage : BaseContentPage
    {
        BirthdayListViewModel _viewModel = null;
       
        public BirthDayListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BirthdayListViewModel();
         

        }
        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
           
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
   
}
