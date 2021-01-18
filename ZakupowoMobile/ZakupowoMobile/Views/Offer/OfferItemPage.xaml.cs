using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;

namespace ZakupowoMobile.Views.Offer
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OfferItemPage : ContentPage
    {
        OfferItem offer;
        public OfferItemPage(OfferItem Offer)
        {
            InitializeComponent();
            this.offer = Offer;
            BindingContext = Offer;
            var images = new List<string>();
            var ItemImages = Offer.OfferPictures;
            foreach(OfferPicture offerPicture in ItemImages)
            {
                images.Add(offerPicture.PathToFile);
            }
            Price.Text = Offer.PriceInfo;
            Title.Text = Offer.Title;
            Description.Text = Offer.Description;
            MainCarouselView.ItemsSource = images;
        }

        private async void BuyItemClicked(object sender, EventArgs e)
        {
            string offerId = offer.OfferID.ToString();
            string quantity = "1";

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "login", Session.user.Login },
                { "offerId", offerId },
                { "quantity", quantity }
            };

            string response = await Bucket.AddOfferToBucket(data);
           

        }
    }
}