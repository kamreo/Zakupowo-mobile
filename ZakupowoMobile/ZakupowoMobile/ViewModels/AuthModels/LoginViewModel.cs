using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ZakupowoMobile.Views;

namespace ZakupowoMobile.ViewModels
{
    public class LoginViewModel 
    {
        public Command LoginCommand
        {
            get;
        }

        public ICommand RegisterCommand => new Command(Register);

        private void Register(object obj)
        {
            
            Application.Current.MainPage = new NavigationPage(new RegistrationPage());


        }
      
    }
}
