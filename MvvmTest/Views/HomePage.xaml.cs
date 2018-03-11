using System;
using System.Collections.Generic;
using System.Linq;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class HomePage : BaseContentPage
    {
        HomeViewModel _viewModel = null;
        public HomePage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new HomeViewModel(this.Navigation);


            flowListView.FlowItemTapped+=async (sender, e) => 
            {
                var model=e.Item as GalleryModel;
                await Navigation.PushAsync(new GalleryDetailsPage(model.id,model.meetingName,model.vanue));
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
