using System;
using System.Collections.Generic;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class PanchangAndChoghadiyaPage : BaseContentPage
    {
        PanchangAndChoghadiyaViewModel _viewModel = null;

        public PanchangAndChoghadiyaPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PanchangAndChoghadiyaViewModel();
            //Panchang  
            sljainTirth.BackgroundColor = Color.FromHex("#ffffff");
            slImpNumber.BackgroundColor = Color.FromHex("#DBDBDB");

            lblJainTirth.TextColor = Color.FromHex("#23A193");
            lblImpNumber.TextColor = Color.FromHex("#B4B4B4");
            cvJain.IsVisible = true;
            cvImp.IsVisible = false;

            _viewModel.GetPanchang();
        }
       

        void Imp_Tapped(object sender, System.EventArgs e)
        {
            sljainTirth.BackgroundColor = Color.FromHex("#DBDBDB");
            slImpNumber.BackgroundColor = Color.FromHex("#ffffff");

            lblImpNumber.TextColor = Color.FromHex("#23A193");
            lblJainTirth.TextColor = Color.FromHex("#B4B4B4");
            cvImp.IsVisible = true;
            cvJain.IsVisible = false;
            _viewModel.GetChoghadiya();
        }

        void Jain_Tapped(object sender, System.EventArgs e)
        {
            sljainTirth.BackgroundColor = Color.FromHex("#ffffff");
            slImpNumber.BackgroundColor = Color.FromHex("#DBDBDB");

            lblJainTirth.TextColor = Color.FromHex("#23A193");
            lblImpNumber.TextColor = Color.FromHex("#B4B4B4");
            cvJain.IsVisible = true;
            cvImp.IsVisible = false;
            _viewModel.GetPanchang();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new NavigationPage(new MainPage());

            return true;
        }
    }
}
