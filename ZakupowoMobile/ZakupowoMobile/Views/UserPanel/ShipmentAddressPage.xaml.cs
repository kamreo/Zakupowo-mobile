using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.ViewModels.UserPanelModels;

namespace ZakupowoMobile.Views.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShipmentAddressPage : ContentPage
    {
        public ShipmentAddressPage()
        {


            InitializeComponent();
            UserPanelViewModel model = new UserPanelViewModel();
            UserPanelViewModel.currentModel = model;
            BindingContext = model;
            
        }
        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            var address = e.Item as ShippingAdress;
      

            try
            {
                UserPanelViewModel.currentAddress = address;
                await Navigation.PushAsync(new ShippingAddressModificationPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void addAddress(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new AddAddressPage());
        }
    }
}