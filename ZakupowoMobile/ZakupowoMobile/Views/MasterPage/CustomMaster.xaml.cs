
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.Views;

namespace QCSMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomMaster : MasterDetailPage
    {
        List<MenuItems> MenuItems;

        public CustomMaster()
        {
            InitializeComponent();


            imgProfilePicture.Source = Session.user.GetProfilePictureAsync().ToString();
            userName.Text = Session.user.GetFullName();
            MenuItems = new List<MenuItems>();

        
            MenuItems.Add(new MenuItems { OptionName = "Profil" });
            MenuItems.Add(new MenuItems { OptionName = "Wyloguj" });

            navigationList.ItemsSource = MenuItems;
            Detail = new NavigationPage(new ListViewData());
        }

        private void Item_Tapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var item = e.Item as MenuItems;

                switch (item.OptionName)
                {
                    case "Produkty":
                        {
                            Detail = new NavigationPage(new ListViewData());
                            IsPresented = false;
                        }
                        break;
                    case "Wiadomości":
                        {
                            
                            IsPresented = false;

                        }
                        break;
                    case "Koszyk":
                        {

                            IsPresented = false;

                        }
                        break;
                    case "Profil":
                        {
                            
                            IsPresented = false;

                        }
                        break;
                    case "Wyloguj":
                        {
                            Session.user = null;
                            Detail = new NavigationPage(new LoginPage());
                            IsPresented = false;

                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
            
        }

    }

    public class MenuItems
    {
        public string OptionName { get; set; }

    }


}

