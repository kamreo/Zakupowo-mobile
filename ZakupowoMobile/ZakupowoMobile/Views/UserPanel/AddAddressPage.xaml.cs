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
using ZakupowoMobile.ViewModels.UserPanelModels;

namespace ZakupowoMobile.Views.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAddressPage : PopupPage
    {
        public AddAddressPage()
        {
            InitializeComponent();
        }

        private async void addAddress(object sender, EventArgs e)
        {
            ShippingAdress model = new ShippingAdress();
            model.AdressID = Session.user.UserID;
            model.Country = country.Text;
            model.City = city.Text;
            model.Street = street.Text;
            model.PostalCode = postalCode.Text;
            model.PremisesNumber = premises.Text;

            bool response = await UserPanelViewModel.AddAddress(model);
            if (response)
            {
                UserPanelViewModel.currentModel.UpdateAddresses();
            }

            await PopupNavigation.Instance.PopAsync(true);
        }
    }


}