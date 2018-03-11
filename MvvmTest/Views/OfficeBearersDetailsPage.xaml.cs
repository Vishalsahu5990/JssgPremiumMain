using System;
using System.Collections.Generic;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class OfficeBearersDetailsPage : BaseContentPage
    {
        BearersDetailsViewModel _viewModel = null;
        public OfficeBearersDetailsPage(string bearerId)
        {
            InitializeComponent();
            BindingContext = _viewModel = new BearersDetailsViewModel(bearerId);

        }
    }
}
