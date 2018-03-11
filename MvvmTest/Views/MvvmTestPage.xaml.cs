using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;

namespace MvvmTest
{
    public partial class MvvmTestPage : ContentPage
    {
        ViewModel.ItemsViewModel viewModel = null;
        public MvvmTestPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ViewModel.ItemsViewModel();
            NavigationPage.SetHasNavigationBar(this, false);
        }
		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
            var item = args.SelectedItem as Model.ItemModel;
            await Navigation.PushAsync(new Views.DetailsPage(item));
            //viewModel.Navigation.Push(Helpers.ViewFactory.CreatePage(new ViewModel.DetailsViewModel()));
            // Manually deselect item
			//ItemsListView.SelectedItem = null;
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);

            //Will notify on scrollToBottom 


            MessagingCenter.Subscribe<object, ObservableCollection<Model.ItemModel>>(this, "ScrollToBottom", (sender,model) => {
    //            var v = ItemsListView.ItemsSource.Cast<object>().LastOrDefault();
				//ItemsListView.ScrollTo(v, ScrollToPosition.End, true);
			});

        }


    }
}
