using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Models;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.ViewModels
{
    public class CategoryItemsDataModel : INotifyPropertyChanged
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
                    var uri = Service.URI + "api/Offers/"+id;
                    var result = await client.GetStringAsync(uri);

                    var OffersList =  JsonConvert.DeserializeObject<List<OfferItem>>(result);
                    List<OfferItem> CategoryOffersList = new List<OfferItem>();
                    foreach (OfferItem offer in OffersList)
                    {
                        if(offer.OfferPictures.Count > 0)
                        {
                            offer.MainImage = offer.OfferPictures[0].PathToFile;
                        }
                       
                        CategoryOffersList.Add(offer);
                        
                    }

                    allItems = CategoryOffersList;
                    Offers = new ObservableCollection<OfferItem>(CategoryOffersList);
                }

            });



        }

        public void ApplyFiters(string name, OfferState state, double priceBegin, double priceEnd )
        {
            List<OfferItem> filteredList = allItems;
            Offers = new ObservableCollection<OfferItem>(filteredList);
            if (name != "" )
            {
                filteredList = filteredList.Where(w => w.Title.ToLower().Contains(name.ToLower())).ToList();
            }
            if (state!=0)
            {
                filteredList = filteredList.Where(w => w.OfferState==state).ToList();
            }
            if (priceBegin > 0 || priceEnd<10000 )
            {
                filteredList = filteredList.Where(w => w.Price < priceEnd && w.Price > priceBegin).ToList();
            }
            Offers = new ObservableCollection<OfferItem>(filteredList);
        }

        public void DeleteFilters()
        {
            Offers = new ObservableCollection<OfferItem>(allItems);
        }

        ObservableCollection<OfferItem> _offers;
        public List<OfferItem> allItems; 
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
