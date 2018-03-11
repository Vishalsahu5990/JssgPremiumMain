using System;
using MvvmTest.CustomRenderer;
using MvvmTest.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PlaceholderEditor), typeof(CustomEditorRenderer))]
namespace MvvmTest.Droid.CustomRenderer
{
    public class CustomEditorRenderer : EditorRenderer
    {
        private string Placeholder { get; set; }
        public CustomEditorRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var element = this.Element as PlaceholderEditor;

            if (Control != null && element != null)
            {
                Placeholder = element.Placeholder;
                Control.SetTextColor(Android.Graphics.Color.Black);
                Control.SetHintTextColor(Android.Graphics.Color.LightGray);
                Control.Hint = element.Placeholder;
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);

            }
        }   

    }
}