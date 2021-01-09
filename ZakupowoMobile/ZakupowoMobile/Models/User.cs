using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.Models
{
    public class User
    {
        public List<object> Auction { get; set; }
        public AvatarImage AvatarImage { get; set; }
        public Bucket Bucket { get; set; }
        public List<object> Bundles { get; set; }
        public List<object> FavouriteOffer { get; set; }
        public List<object> Offers { get; set; }
        public Order Order { get; set; }
        public List<object> ReceivedMessages { get; set; }
        public List<object> SentMessages { get; set; }
        public List<ShippingAdress> ShippingAdresses { get; set; }
        public List<object> Transactions { get; set; }
        public int UserID { get; set; }
        public bool IsActivated { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string EncryptedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string RowVersion { get; set; }


    }
}
