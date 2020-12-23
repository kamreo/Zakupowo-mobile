using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.Models
{
    public class Category
    {

        
        public string CategoryID
        {
            get;
            set;
        }
        public string CategoryName
        {
            get;
            set;
        }
      
        public string CategoryDescription
        {
            get;
            set;
        }


    }
}
