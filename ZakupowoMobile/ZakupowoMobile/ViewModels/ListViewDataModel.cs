using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;
using ZakupowoMobile.Models;

namespace ZakupowoMobile.ViewModels
{
    public class ListViewDataModel : INotifyPropertyChanged
    {
        public ListViewDataModel()
        {
            GetCategories();  
        }

       
        private async void GetCategories()
        {
            using (var client = new HttpClient())
            {
                var uri = "http://192.168.0.15:45455/api/Categories";
                var result = await client.GetStringAsync(uri);

                var CategoryList = JsonConvert.DeserializeObject<List<Category>>(result);

                Categories = new ObservableCollection<Category>(CategoryList);
                
            }


        }

        ObservableCollection<Category> _categories;

        public  ObservableCollection<Category> Categories
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