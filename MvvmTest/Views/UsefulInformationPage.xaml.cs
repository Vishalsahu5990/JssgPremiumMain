using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class UsefulInformationPage : BaseContentPage
    {
        UsefulInfoViewModel _viewModel = null;

        public UsefulInformationPage()
        {
            InitializeComponent();
           

            BindingContext = _viewModel = new UsefulInfoViewModel();

            sljainTirth.BackgroundColor = Color.FromHex("#ffffff");
            slImpNumber.BackgroundColor = Color.FromHex("#DBDBDB");

            lblJainTirth.TextColor = Color.FromHex("#23A193");
            lblImpNumber.TextColor = Color.FromHex("#B4B4B4");
            cvJain.IsVisible = true;
            cvImp.IsVisible = false;
        }

        void Imp_Tapped(object sender, System.EventArgs e)
        {
            sljainTirth.BackgroundColor = Color.FromHex("#DBDBDB");
            slImpNumber.BackgroundColor = Color.FromHex("#ffffff");

            lblImpNumber.TextColor = Color.FromHex("#23A193");
            lblJainTirth.TextColor = Color.FromHex("#B4B4B4");
            cvImp.IsVisible = true;
            cvJain.IsVisible = false;
            _viewModel.GetImpNumbers();
        }

        void Jain_Tapped(object sender, System.EventArgs e)
        {
            sljainTirth.BackgroundColor= Color.FromHex("#ffffff");
            slImpNumber.BackgroundColor = Color.FromHex("#DBDBDB");

            lblJainTirth.TextColor =Color.FromHex("#23A193");
            lblImpNumber.TextColor = Color.FromHex("#B4B4B4");
            cvJain.IsVisible = true;
            cvImp.IsVisible = false;
            _viewModel.GetTirths();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.GetTirths();
        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    } 
}
