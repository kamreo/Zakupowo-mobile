
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZakupowoMobile.Models;
using ZakupowoMobile.Views;
using ZakupowoMobile.Views.Offer;

namespace QCSMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomMaster : MasterDetailPage
    {
        List<MenuItems> MenuItems;

        public CustomMaster()
        {
            InitializeComponent();

            userName.Text = Session.user.GetFullName();
            MenuItems = new List<MenuItems>();

            MenuItems.Add(new MenuItems { OptionName = "Produkty" });
            MenuItems.Add(new MenuItems { OptionName = "Dodaj ofertę" });
            MenuItems.Add(new MenuItems { OptionName = "Koszyk" });
            MenuItems.Add(new MenuItems { OptionName = "Wiadomości" });
            MenuItems.Add(new MenuItems { OptionName = "Profil" });
            MenuItems.Add(new MenuItems { OptionName = "Wyloguj" });

            navigationList.ItemsSource = MenuItems;
            Detail = new NavigationPage(new ListViewData());
            imgProfilePicture.Source = Session.user.Image;
            
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
                    case "Dodaj ofertę":
                        {
                            Detail = new NavigationPage(new AddOfferPage());
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

