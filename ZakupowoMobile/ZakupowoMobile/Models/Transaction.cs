using System;
using System.Collections.Generic;
using System.Text;

namespace ZakupowoMobile.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsChosen { get; set; }
        public virtual User Buyer { get; set; }
        public virtual User Seller { get; set; }
        public virtual ICollection<BucketItem> BucketItems { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
