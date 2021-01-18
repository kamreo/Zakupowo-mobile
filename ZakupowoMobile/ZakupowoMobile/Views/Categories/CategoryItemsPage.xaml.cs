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
using Rg.Plugins.Popup.Services;

namespace ZakupowoMobile.Views.Categories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryItemsPage : ContentPage
    {
        public int categoryId;
        public CategoryItemsDataModel model;
        public CategoryItemsPage(int categoryID)
        {
            InitializeComponent();
            CategoryItemsDataModel model = new CategoryItemsDataModel(categoryID);
            this.model = model;
            BindingContext = model;
            this.categoryId = categoryID;
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

        public void FilterList(string productName="", OfferState state = 0 , double beginPrice = Double.MinValue, double EndPrice = Double.MaxValue)
        {
            model.ApplyFiters(productName, state, beginPrice, EndPrice);
        }

        public void DeleteFilters()
        {
            model.DeleteFilters();
        }

        private void showFilters(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new FilterPage(this));
        }
    }
}