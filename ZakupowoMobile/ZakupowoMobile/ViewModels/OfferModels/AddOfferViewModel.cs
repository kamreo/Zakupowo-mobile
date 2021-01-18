using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
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


        public static async Task<OfferItem> AddOfferAsync(OfferBindingModel offer)
        {
            OfferItem offerItem = null;
            await Task.Run(async () =>
            {
                var client = new HttpClient();
                MultipartFormDataContent content = null;
                List<FileResult> fileResults = AddOfferViewModel.uploadedFiles;

                if (fileResults != null)
                {
                    content = new MultipartFormDataContent("NkdKd9Yk");
                    content.Headers.ContentType.MediaType = "multipart/form-data";
                    foreach (FileResult fileResult in fileResults) content.Add(new StreamContent(File.OpenRead(fileResult.FullPath)), fileResult.FileName, fileResult.FileName);
                }

                content.Headers.ContentType.MediaType = "multipart/form-data";
                var json = JsonConvert.SerializeObject(offer);
                HttpContent httpContent = new StringContent(json);

                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                content.Add(httpContent);

                var response = await client.PostAsync(Service.URI + "api/Offers/", content);

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

        public static List<FileResult> uploadedFiles;

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

        

        ObservableCollection<OfferState> _offerStates = new ObservableCollection<OfferState>(Enum.GetValues(typeof(OfferState)).OfType<OfferState>().ToList());

        public ObservableCollection<OfferState> OfferStates
        {
            get
            {
                return _offerStates;
            }
            set
            {
                _offerStates = value;
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
