using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.ViewModels.OfferModels;

namespace ZakupowoMobile.Views.Offer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BucketPage : ContentPage
    {
        public BucketPage()
        {
            InitializeComponent();

            BucketViewModel model = new BucketViewModel();
            BindingContext = model;
            totalPrice.Text = model.TotalBucketPrice;
         
        }

        private async void BuyBucketItems(object sender, EventArgs e)
        {
            Dictionary<string, string> model = new Dictionary<string, string>()
            {
                { "login", Session.user.Login },
                { "addressId" , (Session.user.ShippingAdresses.First().AdressID).ToString() }

            };

            await BucketViewModel.BuyBucketItems(model);
        }
    }
}