using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Services;
using ZakupowoMobile.ViewModels;

namespace ZakupowoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
           
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new RegistrationViewModel();
        }

        private async void signUp_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailEntry.Text) || string.IsNullOrEmpty(loginEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text) || string.IsNullOrEmpty(passwordRepeatEntry.Text) || string.IsNullOrEmpty(firstNameEntry.Text) || string.IsNullOrEmpty(lastNameEntry.Text))
            {
                await DisplayAlert("Enter data", "Enter valid data", "Ok");
            }
            else if (!(passwordEntry.Text).Equals(passwordRepeatEntry.Text))
            {
                errorContent.IsVisible = true;
                errorMsg.Text = "Hasła się nie zgadzają";

            }
            else
            {
                try
                {
                    string date = dateEntry.Date.ToString("yyyy/MM/dd");
                    bool response = await Service.RegisterUserAsync(loginEntry.Text, emailEntry.Text, passwordEntry.Text,firstNameEntry.Text, lastNameEntry.Text, date);

                    errorContent.IsVisible = true;
                    errorMsg.Text = response.ToString();
                    
                    if (response)
                    {
                        errorContent.IsVisible = true;
                        errorMsg.Text = "Zostałeś zarejestrowany!";
                    }
                    else
                    {
                        errorContent.IsVisible = true;
                        errorMsg.Text = "Uzytkownik o takim samym emailu lub loginie już istnieje!";
                    }
                }catch(Exception ex)
                {
                    errorContent.IsVisible = true;
                    errorMsg.Text = ex.Message;
                }
            }

        }
    }
}