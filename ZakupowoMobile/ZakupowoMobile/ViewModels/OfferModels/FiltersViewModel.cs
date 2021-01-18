using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ZakupowoMobile.Models;

namespace ZakupowoMobile.ViewModels.OfferModels
{
    class FiltersViewModel : INotifyPropertyChanged
    {

        public FiltersViewModel()
        {

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
