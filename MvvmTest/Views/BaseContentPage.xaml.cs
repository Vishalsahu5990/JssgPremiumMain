using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this,false);
        }
    }
}
