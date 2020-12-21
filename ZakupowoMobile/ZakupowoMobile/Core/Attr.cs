using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ZakupowoMobile.Core
{
    class Attr
    {
      
            public static readonly BindableProperty valueProperty =
                BindableProperty.CreateAttached("value", typeof(int), typeof(Attr), defaultValue: -1);

            public static int GetValue(BindableObject view)
            {
                return (int)view.GetValue(valueProperty);
            }

            public static void SetValue(BindableObject view, int value)
            {
                view.SetValue(valueProperty, value);
            }
        
    }
}
