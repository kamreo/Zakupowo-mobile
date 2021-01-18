using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Services;

namespace ZakupowoMobile.Models
{
    public class Bucket
    {
        public List<BucketItem> BucketItems { get; set; }
        public int BucketID { get; set; }
       
        
        public static double TotalPrice(List<BucketItem> items)
        {
            double totalPrice = 0;
            foreach(var item in items)
            {
                totalPrice += item.TotalPrice;
            }
            return totalPrice;
        }

        public static async Task<string> AddOfferToBucket(Dictionary<string,string> model)
        {
            string Response = String.Empty;
            await Task.Run(async () =>
            {
                var client = new HttpClient();

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(Service.URI + "api/Users/AddOfferToBucket", httpContent); ;
                Response = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);

            });
            return Response;
        }
    }
}
