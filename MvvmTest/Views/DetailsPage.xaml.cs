using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class DetailsPage : ContentPage
    {
        ViewModel.DetailsViewModel viewModel = null;
        public DetailsPage()
        {
            InitializeComponent();
           
        }
        public DetailsPage(Model.ItemModel item)
		{
			InitializeComponent();
            BindingContext = viewModel = new ViewModel.DetailsViewModel(item);
		}
    }
}
