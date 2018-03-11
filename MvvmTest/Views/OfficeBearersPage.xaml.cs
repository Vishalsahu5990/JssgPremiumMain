using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using MvvmTest.ViewModel;
using MvvmTest.Services;
using PortableLibrary.Models;

namespace MvvmTest.Views
{
    public partial class OfficeBearersPage : BaseContentPage
    {
        BearersViewModel _viewModel = null;
        public OfficeBearersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new BearersViewModel(this.Navigation);
            //listView.ItemsSource = Enumerable.Range(0, 20);
            listView.ItemTapped+= async(sender, e) => 
            {
                if (e.Item == null) return; // don't do anything if we just de-selected the row
                                                    // do something with e.SelectedItem
               
                var bearerModel = e.Item as BearersModel;
                if(!string.IsNullOrEmpty(bearerModel.bearDesc))
                await Navigation.PushAsync(new OfficeBearersDetailsPage(bearerModel.id));
                else
                    ((ListView)sender).SelectedItem = null; // de-select the row
            };
           
        }
        void Handle_OnHomeClicked(object sender, System.EventArgs e)
        {

        }

        void Handle_OnMenuClicked(object sender, System.EventArgs e)
        {

        }
    }
}
