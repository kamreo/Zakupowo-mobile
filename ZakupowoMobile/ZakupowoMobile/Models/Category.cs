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
        public Category(string categoryID)
        {
            CategoryID = categoryID;
        }

        public string CategoryID
        {
            get;
            set;
        }
        public string ImageSource
        {
            get {
                switch (this.CategoryID)
                {
                    case "1":
                        return "cpu.png";
                    case "2":
                        return "dress.png";
                    case "3":
                        return "farming.png";
                    case "4":
                        return "house.png";
                    case "5":
                        return "shop.png";
                    case "6":
                        return "car.png";
                    case "7":
                        return "running.png";
                    case "8":
                        return "pethouse.png";
                    case "9":
                        return "playtime.png";
                    case "10":
                        return "paintpalette.png";
                    case "11":
                        return "realestate.png";
                    case "12":
                        return "heart.png";
                    case "13":
                        return "electronics.png";
                    case "14":
                        return "magnifyingglass.png";
                    default:
                        return "";
                }

            }
            
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
