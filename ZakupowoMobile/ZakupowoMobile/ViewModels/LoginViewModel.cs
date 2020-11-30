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
            
            await App.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
         

        }
      
    }
}
