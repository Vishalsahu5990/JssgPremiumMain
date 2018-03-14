using System;
using System.Collections.Generic;
using System.Diagnostics;
using MvvmTest.Views;
using Xamarin.Forms;

namespace MvvmTest.UserControls
{
    public partial class BackNavigationBar : Grid
    {
        public event EventHandler MenuClicked;
        public event EventHandler HomeClicked;
        private void OnMenuClicked(object sender, EventArgs e)
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                Navigation.PopAsync();
                Debug.WriteLine("________________");
            }
            else
            {
                Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!");
                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            //MessagingCenter.Send<object>(this, "OpenMenu");
            //if (MenuClicked != null)
            //{

            //    MenuClicked(this, EventArgs.Empty);
            //}
        }

        private void OnHomeClicked(object sender, EventArgs e)
        {

            App.Current.MainPage = new NavigationPage(new MainPage());


            if (HomeClicked != null)
            {
                HomeClicked(this, EventArgs.Empty);

            }
        }

        public BackNavigationBar()
        {
            InitializeComponent();

        }

    }
}

