using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZakupowoMobile.Views;

namespace ZakupowoMobile.ViewModels
{
    public class RegistrationViewModel
    {
      
    
        public Command RegistrationCommand
        {
            get;
        }


        public ICommand LoginCommand => new Command(Login);

        private async void Login(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());

        }
    
    }
}