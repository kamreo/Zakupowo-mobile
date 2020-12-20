using QCSMobile.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Services;
using ZakupowoMobile.ViewModels;

namespace ZakupowoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        public LoginPage()
        {

            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = new LoginViewModel();
            loginEntry.Text = "kamreo";
            passwordEntry.Text = "haslo1223";

        }

        private async void signIn_Clicked(object sender, EventArgs e)
        {
            if ( string.IsNullOrEmpty(loginEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text) )
            {
                await DisplayAlert("Enter data", "Enter valid data", "Ok");
            }
            else
            {
                try
                {
           
                    bool response = await Service.LoginUserAsync(loginEntry.Text, passwordEntry.Text);

                    if (response)
                    {
                        
                        await Navigation.PushModalAsync(new CustomMaster());
                    }
                    else
                    {

                        errorContent.IsVisible = true;
                        errorMsg.Text = "Podane dane są nieprawidłowe!";
                    }
                }
                catch (AggregateException err)
                {
                    foreach (var errInner in err.InnerExceptions)
                    {
                        Debug.WriteLine(errInner); //this will call ToString() on the inner execption and get you message, stacktrace and you could perhaps drill down further into the inner exception of it if necessary 
                    };
                }
            }
        }
    }
}