using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.Services;
using ZakupowoMobile.ViewModels.UserPanelModels;

namespace ZakupowoMobile.Views.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AvatarPage : ContentPage
    {
        public AvatarPage()
        {
            InitializeComponent();
            if (Session.user.AvatarImage.PathToFile.Contains("http")) resultImage.Source = Session.user.AvatarImage.PathToFile;
            else resultImage.Source = Service.URI + Session.user.AvatarImage.PathToFile;
        }

        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            UserPanelViewModel.uploadedFile = null;
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Wybierz zdjęcie"
            });

            if (pickResult != null)
            {
                UserPanelViewModel.uploadedFile = pickResult;
                var stream = await pickResult.OpenReadAsync();
                resultImage.Source = ImageSource.FromStream(() => stream);
                
            }
        }

        async void changeAvatar(System.Object sender, System.EventArgs e)
        {
            if(UserPanelViewModel.uploadedFile != null)
            {
                bool response = await UserPanelViewModel.ChangeAvatar();
                if (response == true)
                {
                    output.TextColor = Color.Green;
                    output.Text = "Pomyślnie zmieniono avatar";

                }
                else
                {
                    output.TextColor = Color.Red;
                    output.Text = "Nie udało się zmienić avataru";
                }
            }
            else
            {
                output.TextColor = Color.Red;
                output.Text = "Nie wybrano zdjęcia!";
            }
        }
        

    }
}