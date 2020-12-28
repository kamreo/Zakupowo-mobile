using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Models;
using ZakupowoMobile.Models.BindingModels;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.ViewModels
{
    public class AddOfferViewModel : INotifyPropertyChanged
    {
        public AddOfferViewModel()
        {
            GetCategories();
        }


        public static async Task<OfferItem> AddOfferAsync(Models.BindingModels.OfferBindingModel offer)
        {
            OfferItem offerItem = null;
            await Task.Run(async () =>
            {
                var client = new HttpClient();
               

                var json = JsonConvert.SerializeObject(offer);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Offers/Add", httpContent);
                
                if (response.IsSuccessStatusCode)
                {
                    offerItem = JsonConvert.DeserializeObject<OfferItem>(response.Content.ReadAsStringAsync().Result);
                }


            });
            return offerItem;
        }
        private async void GetCategories()
        {
            using (var client = new HttpClient())
            {
                var uri = Service.URI + "api/Categories";
                var result = await client.GetStringAsync(uri);

                var CategoryList = JsonConvert.DeserializeObject<List<Category>>(result);

                Categories = new ObservableCollection<Category>(CategoryList);

            }

        }

        ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

 
}
