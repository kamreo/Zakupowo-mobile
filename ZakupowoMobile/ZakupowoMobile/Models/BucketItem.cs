using System;
using System.Collections.Generic;
using System.Text;

namespace ZakupowoMobile.Models
{
    public class BucketItem
    {
        public int BucketItemID { get; set; }
        public int Quantity { get; set; }
        public double TotalPrice { get; set; }
        public bool IsChosen { get; set; }
        public virtual OfferItem Offer { get; set; }
    }
}
