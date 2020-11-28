using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZakupowoMobile.Views;

namespace ZakupowoMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand
        {
            get;
        }

        public ICommand RegisterCommand => new Command(Register);

        private async void Register(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await App.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
         

        }
      
    }
}
