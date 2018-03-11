using System;
using MvvmTest.CustomRenderer;
using MvvmTest.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(ExtendedListViewRenderer))]
namespace MvvmTest.Droid.CustomRenderer
{
    public class ExtendedListViewRenderer: ListViewRenderer
    {
        private bool ScrollingEnabled { get; set; }
        private bool ShowScroller { get; set; }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);

            var element = this.Element as ExtendedListView;
            if (Control == null && element == null)
                return;

            ScrollingEnabled = element.ScrollingEnabled;
            ShowScroller = element.ShowScroller;

            var tableView = Control as Android.Widget.ListView;
            //tableView.ScrollIndicators=
            tableView.VerticalScrollBarEnabled = ShowScroller;


        }


    }
}