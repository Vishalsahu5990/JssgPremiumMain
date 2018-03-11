using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace MvvmTest.Popups
{
    public partial class GalleryPopupPage : PopupPage
    {
        public GalleryPopupPage(string galleryImage)
        {
            InitializeComponent();
            imgGallery.Source = galleryImage;
            slMainLayout.HeightRequest = Height;
            imgGallery.HeightRequest = Height;


        }
        public async void Cross_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }

    }
}
