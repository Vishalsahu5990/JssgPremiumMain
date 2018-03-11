using System;
using Xamarin.Forms;

namespace MvvmTest.Model
{
    public class MasterPageItemModel
    {
        public MasterPageItemModel()
        {
        }
        public string Title { get; set; }
        public string IconSource { get; set; }
        public Type TargetType { get; set; }
        public INavigation navigation { get; set; }
    }
}
