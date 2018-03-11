using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmTest.Helpers;
using MvvmTest.ViewModel;
using PortableLibrary.Models;
using Xamarin.Forms;

namespace MvvmTest.Views
{
    public partial class MembersPage : BaseContentPage
    {
        MembersViewModel _viewModel = null;
        public static BindableProperty TextChangedCommandProperty = BindableProperty.Create("SearchTextProperty", typeof(ICommand), typeof(SearchBar));
        public ICommand TextChangedCommand
        {
            get
            {
                return (ICommand)this.GetValue(TextChangedCommandProperty);
            }
            set
            {
                this.SetValue(TextChangedCommandProperty, value);
            }
        }

        public MembersPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MembersViewModel(this);
            listView.ItemTapped+= ListView_ItemTapped;
            searchBar.TextChanged+= SearchBar_TextChanged;
        }

       async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var model = e.Item as MemberModel;
            await Navigation.PushAsync(new MemberDetailsPage(model.id));
        }

        void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Will send the immediate control to viewmodel on text changed
            string toSearch = e.NewTextValue;
            if (toSearch == null)
                toSearch = "";
            if (this.TextChangedCommand != null && this.TextChangedCommand.CanExecute(e))
            {
                this.TextChangedCommand.Execute(toSearch);
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();


        }
    }
}
