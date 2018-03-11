using System;
using Xamarin.Forms;

namespace MvvmTest.CustomRenderer
{
    public class ExtendedButton: Button
    {
        #region Padding    

        public static BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(ExtendedButton), default(Thickness), defaultBindingMode: BindingMode.OneWay);

        public Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        #endregion Padding

    }
}
