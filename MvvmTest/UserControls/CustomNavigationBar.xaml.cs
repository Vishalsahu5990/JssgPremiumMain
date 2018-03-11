using System;
using System.Collections.Generic;
using MvvmTest.Helpers;
using MvvmTest.Views;
using Xamarin.Forms;

namespace MvvmTest.UserControls
{
    public partial class CustomNavigationBar : Grid
    {
        public event EventHandler MenuClicked;
        public event EventHandler HomeClicked;
        private void OnMenuClicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<object>(this, "OpenMenu");
            if (MenuClicked != null)
            {
                
                MenuClicked(this, EventArgs.Empty);
            }
        }

        private void OnHomeClicked(object sender, EventArgs e)
        {
            
                App.Current.MainPage = new NavigationPage(new MainPage());
           
            
            if (HomeClicked != null)
            {
                HomeClicked(this, EventArgs.Empty);
               
            }
        }

        public CustomNavigationBar()
        {
            InitializeComponent();
           
        }
       
    }
}
