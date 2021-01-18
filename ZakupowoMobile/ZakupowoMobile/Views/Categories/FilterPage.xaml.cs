using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.ViewModels.OfferModels;

namespace ZakupowoMobile.Views.Categories
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilterPage : PopupPage
    {
        public CategoryItemsPage page;
        public FilterPage(CategoryItemsPage page)
        {
            InitializeComponent();
            this.page = page;
            BindingContext = new FiltersViewModel();
        }

        private void Slide_ValueChanged(object sender, EventArgs e)
        {
            string rangeOutput = minValue.Value.ToString() + " - " + maxValue.Value.ToString();
            range.Text = rangeOutput;
        }


        private async void applyFilters(object sender, EventArgs e)
        {
            string name = "";
            if (productName.Text != null)
            {
                 name = productName.Text;
            }

            double min = minValue.Value;
            double max = maxValue.Value;
            OfferState state = 0;
            if (StateBinder.SelectedItem!=null) state = (OfferState)StateBinder.SelectedItem;
       

            page.FilterList(name,state,min, max);
            await PopupNavigation.Instance.PopAsync(true);

        }

        private async void deleteFilters(object sender, EventArgs e)
        { 
            page.DeleteFilters();
            await PopupNavigation.Instance.PopAsync(true);

        }


    }
}