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
        public OfferItemPage(OfferItem Offer)
        {
            InitializeComponent();
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
          
        }
    }
}