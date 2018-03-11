using System;
using System.Collections.Generic;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class GroupIntroductionPage : BaseContentPage
    {
        GroupIntroductionViewModel _viewModel = null;
        public GroupIntroductionPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new GroupIntroductionViewModel();
        }
    }
}
