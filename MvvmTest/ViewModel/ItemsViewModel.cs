using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmTest.ViewModel
{
    public class ItemsViewModel:BaseViewModel
    {
        public ObservableCollection<Model.ItemModel> Items { get; set; }
		public Command LoadItemsCommand { get; set; }
        public Command AddItemsCommand { get; set; }

        public ItemsViewModel()
        {
			Items = new ObservableCollection<Model.ItemModel>();

            // Is pull to refresh command 
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //Add items command 
            AddItemsCommand = new Command(async () => await AddItems());
           
        }
        async Task AddItems()
        {
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Add(new Model.ItemModel
						{
							Id = "11",
							Text = "Added by button.",
							Description = "None"
						});

                //To scroll down items after adding the new items.
                ScrollToBottom();



			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}  
        }
        async Task  ExecuteLoadItemsCommand()
		{
			if (IsBusy)
				return;

			IsBusy = true;

			try
			{
				Items.Clear();
				
                for (int i = 0; i < 10;i++)
				{
                    //Condition to create variation in listview height
                    if(i%2==0)
                    Items.Add(new Model.ItemModel{
                        Id=i.ToString(),
                        Text="Hello",
                        Description="None"
                    });
                    else
						Items.Add(new Model.ItemModel
						{
							Id = i.ToString(),
							Text = "Hello this is testing text so that we can test the row height property is adjusting its height accordig to text or not." +
                            "Hello this is testing text so that we can test the row height property is adjusting its height accordig to text or not",

							Description = "None"
						});
                        
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
			finally
			{
				IsBusy = false;
			}
		}
        public void ScrollToBottom()
        {
            try
            {
                MessagingCenter.Send<object, ObservableCollection<Model.ItemModel>>(this, "ScrollToBottom",Items);
				
            }
            catch (Exception ex)
            {

            }
        }
    }
}
