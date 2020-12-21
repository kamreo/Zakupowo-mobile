using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Core;
using ZakupowoMobile.Models;
using ZakupowoMobile.Services;
using ZakupowoMobile.ViewModels;
using ZakupowoMobile.Views.Categories;
using static ZakupowoMobile.Services.Service;

namespace ZakupowoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewData : ContentPage
    {
        
        public ListViewData()
        {
        
            InitializeComponent();
            BindingContext = new ListViewDataModel();
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var category = e.Item as Category;
            var categoryId = Convert.ToInt32(category.CategoryID);

            try
            {
                await Navigation.PushAsync(new CategoryItemsPage(categoryId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}