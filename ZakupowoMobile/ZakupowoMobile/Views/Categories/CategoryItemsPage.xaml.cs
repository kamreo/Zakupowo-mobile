using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.Views.Offer;

namespace ZakupowoMobile.Views.Categories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryItemsPage : ContentPage
    {
        public CategoryItemsPage(int categoryID)
        {
            InitializeComponent();
            BindingContext = new CategoryItemsDataModel(categoryID);
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var offer = e.Item as OfferItem;
            

            try
            {
                await Navigation.PushAsync(new OfferItemPage(offer));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}