using System;
using Xamarin.Forms;

namespace MvvmTest.CustomRenderer
{
    public class ExtendedListView: ListView
    {
        public static BindableProperty ScrollingEnabledProperty
        = BindableProperty.Create("ScrollingEnabled", typeof(bool), typeof(ExtendedListView)
                                  , false, BindingMode.TwoWay, null, null, null, null);
        public bool ScrollingEnabled
        {
            get { return (bool)base.GetValue(ExtendedListView.ScrollingEnabledProperty); }
            set { base.SetValue(ExtendedListView.ScrollingEnabledProperty, value); }
        }

        public static BindableProperty ShowScrollerProperty
        = BindableProperty.Create("ShowScroller", typeof(bool), typeof(ExtendedListView), false, BindingMode.TwoWay, null, null, null, null);
        public bool ShowScroller
        {
            get { return (bool)base.GetValue(ExtendedListView.ShowScrollerProperty); }
            set { base.SetValue(ExtendedListView.ShowScrollerProperty, value); }
        }

        public ExtendedListView()
        {
        }
    }
   
}

