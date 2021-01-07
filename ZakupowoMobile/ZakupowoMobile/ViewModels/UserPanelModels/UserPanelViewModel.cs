using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZakupowoMobile.Models;
using ZakupowoMobile.Models.BindingModels;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.ViewModels.UserPanelModels
{
    public class UserPanelViewModel :INotifyPropertyChanged
    { 
        public UserPanelViewModel()
        {
           Adresses = new ObservableCollection<ShippingAdress>(Session.user.ShippingAdresses);

        }

       
        public static async Task<bool> ChangePersonalData(PersonalDataBindingModel model)
        {
            bool Response = false;
            await Task.Run(async () =>
            {
                var client = new HttpClient();
              

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Users/ChangeData", httpContent); ;
                var user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                

                if (response.IsSuccessStatusCode)
                {

                    Session.user = user;
                    Response = true;
                }


            });
                return Response;
        }

        public static async Task<bool> AddAddress(ShippingAdress model)
        {
            bool Response = false;
            await Task.Run(async () =>
            {
                var client = new HttpClient();


                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Users/AddAddress", httpContent); ;
                var user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);


                if (response.IsSuccessStatusCode)
                {

                    Session.user = user;
                    Response = true;
                }


            });
            return Response;
        }

        public static async Task<bool> ChangeAddressData(ShippingAdress model)
        {
            bool Response = false;
            await Task.Run(async () =>
            {
                var client = new HttpClient();
              

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Users/ChangeAddressData", httpContent); ;
                var user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
                

                if (response.IsSuccessStatusCode)
                {

                    Session.user = user;
                    Response = true;
                }


            });
            return Response;
        }

        public static async Task<bool> DeleteAddress(ShippingAdress model)
        {
            bool Response = false;
            await Task.Run(async () =>
            {
                var client = new HttpClient();

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Users/DeleteAddress", httpContent); ;
                var user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);


                if (response.IsSuccessStatusCode)
                {

                    Session.user = user;
                    Response = true;
                }


            });
            return Response;
        }



        public static ShippingAdress currentAddress;
        public static UserPanelViewModel currentModel;
        ObservableCollection<ShippingAdress> _adresses;
        
        public ObservableCollection<ShippingAdress> Adresses
        {
            get
            {
                return _adresses;
            }
            set
            {
               _adresses = value;
                OnPropertyChanged();
            }
        }

        public void UpdateAddresses()
        {
            this.Adresses = null;
            this.Adresses = new ObservableCollection<ShippingAdress>(Session.user.ShippingAdresses);
            OnPropertyChanged();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }







    }
}