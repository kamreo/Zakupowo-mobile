using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace ZakupowoMobile.Models.BindingModels
{
    public class OfferBindingModel
    {
        public string Title { get; set; }

        public string Description { get; set; }
        public string Price { get; set; }
        public OfferState OfferState { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public double InStockOriginaly { get; set; }

     

    }
}
