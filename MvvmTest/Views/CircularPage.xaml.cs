using System;
using System.Collections.Generic;
using System.Linq;
using MvvmTest.Services;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class CircularPage : BaseContentPage
    {
        CircularViewModel _viewModel = null;
        public CircularPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CircularViewModel(this.Navigation);
            //listView.ItemsSource = Enumerable.Range(0, 5);
            listView.ItemTapped+= (sender, e) => 
            {
                if (e.Item == null) return; // don't do anything if we just de-selected the row
                ((ListView)sender).SelectedItem = null; // de-select the row
            }; 
        }
       
    }
}
