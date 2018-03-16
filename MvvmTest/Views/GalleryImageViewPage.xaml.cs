using System;
using System.Collections.Generic;
using MvvmTest.ViewModel;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class GalleryImageViewPage : BaseContentPage
    {
        GalleryImageViewModel viewModel = null;
        public GalleryImageViewPage(string galleryImage)
        {
            InitializeComponent();
            BindingContext = viewModel = new GalleryImageViewModel();
            imgGallery.Source = galleryImage;
            imgGallery.HeightRequest = Height;
        }
    }
}
