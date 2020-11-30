using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.Services;
using ZakupowoMobile.ViewModels;
using static ZakupowoMobile.Services.Service;

namespace ZakupowoMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewData : ContentPage
    {
        
        public ListViewData()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new ListViewDataModel();
        }

       
    }
}