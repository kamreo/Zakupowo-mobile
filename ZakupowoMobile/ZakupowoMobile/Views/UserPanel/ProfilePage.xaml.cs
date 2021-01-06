using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.Models.BindingModels;
using ZakupowoMobile.ViewModels.UserPanelModels;

namespace ZakupowoMobile.Views.UserPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            User user = Session.user;
            name.Text = user.FirstName;
            surname.Text = user.LastName;
            email.Text = user.Email;
            phone.Text = user.Phone;
        }

        private async void changeData(object sender, EventArgs e)
        {
            PersonalDataBindingModel model = new PersonalDataBindingModel();
            model.Login = Session.user.Login;
            model.FirstName = name.Text;
            model.LastName = surname.Text;
            model.Email = email.Text;
            model.Phone = phone.Text;

            bool response = await UserPanelViewModel.ChangePersonalData(model);


        }
    }
}