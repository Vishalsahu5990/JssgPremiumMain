    using System;
using System.Collections.Generic;
using System.Linq;
using MvvmTest.ViewModel;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using PortableLibrary.Models;

namespace MvvmTest.Views
{
    public partial class GalleryDetailsPage : BaseContentPage
    {
        GalleryDetailsViewModel _viewModel = null;
        public GalleryDetailsPage(string galleryId,string meetingName,string venu)
        {
            InitializeComponent();
            BindingContext = _viewModel = new GalleryDetailsViewModel(galleryId,meetingName,venu);
            //flowListView.FlowItemsSource = Enumerable.Range(0, 10).ToList();
            flowListView.FlowItemTapped+= (sender, e) => 
            {
                if (e.Item == null) return;

                var model = e.Item as GalleryModel;
                Navigation.PushPopupAsync(new Popups.GalleryPopupPage(model.galleryPhoto));
            };
        }
    }
}
