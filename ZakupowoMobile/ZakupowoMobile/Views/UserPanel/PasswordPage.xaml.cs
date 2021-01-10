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
    public partial class PasswordPage : ContentPage
    {
        public PasswordPage()
        {
            InitializeComponent();
            
        }

        private async void changePassword(object sender, EventArgs e)
        {
            string old = oldPassword.Text;
            string change = newPassword.Text;
            string repeat = newPasswordRepeat.Text;

            if(change==repeat)
            {
                Dictionary<string, string> data = new Dictionary<string, string>
                {
                    { "login", Session.user.Login },
                    { "newPassword", change },
                    { "oldPassword", old }
                };
                string response = await UserPanelViewModel.ChangePassword(data);
                output.Text = response;
                output.TextColor = Color.Green;
            }
            else
            {
                output.Text = "Powtórzone hasło się nie zgadza!";
                output.TextColor = Color.Red;
            }

        }
    }
}