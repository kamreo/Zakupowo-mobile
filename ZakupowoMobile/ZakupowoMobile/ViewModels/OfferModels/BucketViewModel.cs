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
using ZakupowoMobile.Services;

namespace ZakupowoMobile.ViewModels.OfferModels
{
    class BucketViewModel : INotifyPropertyChanged
    {

        public BucketViewModel()
        {

            GetBucketItems(Session.user.UserID);

        }
        private async void GetBucketItems(int id)
        {

            await Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var uri = Service.URI + "api/Bucket/" + id;
                    var result = await client.GetAsync(uri);
                    if (result.IsSuccessStatusCode)
                    {
                        var data = await result.Content.ReadAsStringAsync();

                        try
                        {
                            var bucketItems = JsonConvert.DeserializeObject<List<BucketItem>>(data);
                            TotalBucketPrice = Bucket.TotalPrice(bucketItems).ToString();
                            BucketItems = new ObservableCollection<BucketItem>(bucketItems);
                        }
                        catch
                        {
                            Message = JsonConvert.DeserializeObject<string>(data);
                        }
                    }
                }
            });


        }

        public static async Task<string> DeleteBucketItem(Dictionary<string, string> model)
        {
            string Response = String.Empty;
            await Task.Run(async () =>
            {
                var client = new HttpClient();

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Bucket/RemoveFromBucket", httpContent); ;


            });
            return Response;
        }

        public static async Task<string> BuyBucketItems(Dictionary<string, string> model)
        {
            string Response = String.Empty;
            await Task.Run(async () =>
            {
                var client = new HttpClient();

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Bucket/BuyBucketItems", httpContent); ;
                

            });
            return Response;
        }


        public string TotalBucketPrice;

        ObservableCollection<BucketItem> _bucketItems;

        public static string Message="";
        public ObservableCollection<BucketItem> BucketItems
        {
            get
            {
                return _bucketItems;
            }
            set
            {
                _bucketItems = value;
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

