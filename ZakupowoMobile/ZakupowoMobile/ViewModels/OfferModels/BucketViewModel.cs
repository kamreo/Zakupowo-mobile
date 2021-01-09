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

