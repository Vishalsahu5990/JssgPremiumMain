using System;
using MvvmTest.CustomRenderer;
using MvvmTest.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedListView), typeof(ExtendedListViewRenderer))]
namespace MvvmTest.iOS.CustomRenderer
{
    public class ExtendedListViewRenderer: ListViewRenderer
    {
        private bool ScrollingEnabled { get; set; }
        private bool ShowScroller { get; set; }
        UITableView tableView = null;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            var element = this.Element as ExtendedListView;
            if (Control == null&& element == null)
                return;
            if (element != null)
            {
                ScrollingEnabled = element.ScrollingEnabled;
                ShowScroller = element.ShowScroller;
            }
            tableView = Control as UITableView;
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.ScrollEnabled = ScrollingEnabled;
            tableView.ShowsVerticalScrollIndicator = ShowScroller;
            //tableView.AllowsSelection = false;


        }

    }
}