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
            BindingContext = new UserPanelViewModel();
            
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


    }
}