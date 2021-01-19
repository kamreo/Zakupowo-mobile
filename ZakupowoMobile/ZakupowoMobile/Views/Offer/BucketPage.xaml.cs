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
        BucketViewModel viewModel = null;
        public BucketPage()
        {
            InitializeComponent();

            this.viewModel = new BucketViewModel();
            BindingContext = viewModel;
            totalPrice.Text = viewModel.TotalBucketPrice;
         
        }

        private async void BuyBucketItems(object sender, EventArgs e)
        {
            Dictionary<string, string> model = new Dictionary<string, string>()
            {
                { "login", Session.user.Login },
                { "addressId" , (Session.user.ShippingAdresses.First().AdressID).ToString() }

            };

            await BucketViewModel.BuyBucketItems(model);
            this.viewModel = new BucketViewModel();
            this.BindingContext = viewModel;
        }

        private async void deleteItem(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            BucketItem item = (BucketItem)button.CommandParameter;
            Dictionary<string, string> model = new Dictionary<string, string>()
            {
                { "login" , Session.user.Login},
                { "offerId" , (item.Offer.OfferID).ToString()},
            };

            string reponse = await BucketViewModel.DeleteBucketItem(model);
            this.viewModel = new BucketViewModel();
            this.BindingContext = viewModel;
        }
    }
}