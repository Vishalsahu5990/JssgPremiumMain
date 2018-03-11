using System;
using MvvmTest.CustomRenderer;
using MvvmTest.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace MvvmTest.Droid.CustomRenderer
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                this.Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
                this.Control.Gravity = Android.Views.GravityFlags.CenterVertical;
                this.Control.SetPadding(5,5,5,5);


            }
        }
    }
}
