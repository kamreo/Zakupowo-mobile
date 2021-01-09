using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.ViewModels.OfferModels;

namespace ZakupowoMobile.Views.Offer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BucketPage : ContentPage
    {
        public BucketPage()
        {
            InitializeComponent();
            BindingContext = new BucketViewModel();
        }
    }
}