using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.Models
{
    public class OfferItem
    {

        public string MainImage { get; set; }

        public int OfferID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public bool IsActive { get; set; }

        public object Stocking { get; set; }

        public double InStockOriginaly { get; set; }

        public double InStockNow { get; set; }

        public double Price { get; set; }
        public int UserID { get; set; }
        public int CategoryID { get; set; }

        public List<OfferPicture> OfferPictures { get; set; }


        public string PriceInfo 
        {
            get { return "Cena: " + (this.Price).ToString(); }

            set { }
        }

    }
}
