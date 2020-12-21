using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Models;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.ViewModels
{
    class CategoryItemsDataModel : INotifyPropertyChanged
    {
        public CategoryItemsDataModel(int id )
        {

            GetCategoryItems(id);
        }

        private async void GetCategoryItems(int id)
        {
            
            await Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var uri = Service.URI + "api/Offers";
                    var result = await client.GetStringAsync(uri);

                    var OffersList =  JsonConvert.DeserializeObject<List<OfferItem>>(result);
                    List<OfferItem> CategoryOffersList = new List<OfferItem>();
                    foreach (OfferItem offer in OffersList)
                    {
                        offer.MainImage = offer.OfferPictures[0].PathToFile;
                        if (offer.CategoryID == id) CategoryOffersList.Add(offer);
                        
                    }
                    Offers = new ObservableCollection<OfferItem>(CategoryOffersList);
                }

            });



        }

        ObservableCollection<OfferItem> _offers;

        public ObservableCollection<OfferItem> Offers
        {
            get
            {
                return _offers;
            }
            set
            {
                _offers = value;
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
