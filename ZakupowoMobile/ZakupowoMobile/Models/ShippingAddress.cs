
using System;
using System.Collections.Generic;
using System.Text;

namespace ZakupowoMobile.Models
{
    public class ShippingAdress
    {
        public string AdressName {
            get
            {
                return "Adres " + this.AdressID.ToString();
            }
            set
            {
                this.AdressName = value;
            } 
        }

       
        public int AdressID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PremisesNumber { get; set; }
        public string PostalCode { get; set; }
    }
}
