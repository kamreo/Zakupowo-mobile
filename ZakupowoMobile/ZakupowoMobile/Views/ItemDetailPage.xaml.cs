using System.ComponentModel;
using Xamarin.Forms;
using ZakupowoMobile.ViewModels;

namespace ZakupowoMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}