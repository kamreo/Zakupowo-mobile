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
    public partial class ShippingAddressModificationPage : ContentPage
    {
        public ShippingAddressModificationPage()
        {
            InitializeComponent();
            ShippingAdress address = UserPanelViewModel.currentAddress;
            country.Text = address.Country;
            city.Text = address.City;
            street.Text = address.Street;
            premises.Text = address.PremisesNumber;
            postalCode.Text = address.PostalCode;

        }
        private async void changeData(object sender, EventArgs e)
        {
           ShippingAdress model = new ShippingAdress();
            model.Country = country.Text;
            model.City = city.Text;
            model.Street = street.Text;
            model.PremisesNumber = premises.Text;
            model.PostalCode = postalCode.Text;
            model.AdressID = UserPanelViewModel.currentAddress.AdressID;

            bool response = await UserPanelViewModel.ChangeAddressData(model);
           


        }
        private async void delete(object sender, EventArgs e)
        {
            ShippingAdress model = new ShippingAdress();
            model.AdressID = UserPanelViewModel.currentAddress.AdressID;

            bool response = await UserPanelViewModel.DeleteAddress(model);
            if (response) await Navigation.PopAsync();

        }
    }
}