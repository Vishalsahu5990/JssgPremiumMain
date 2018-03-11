using System;
namespace MvvmTest.ViewModel
{
    public class DetailsViewModel:BaseViewModel
    {
        public Model.ItemModel Item = null;
        public DetailsViewModel(Model.ItemModel item)
        {
            Title = item?.Description;
			Item = item;
        }
    }
}
