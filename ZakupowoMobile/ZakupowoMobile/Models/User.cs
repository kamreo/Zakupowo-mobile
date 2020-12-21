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
    class User
    {
        public User(int ID)
        { 
            this.ID = ID;
            this.Image = GetProfilePictureAsync(ID).Result;
        }

        public int ID
        {
            get;
            set;
        }

        public string Image
        {
            get;
            set;
        }

        public string GetFullName()
        {
            return "";
        }


        public async Task<string> GetProfilePictureAsync(int ID)
        {
            var imageUri = "";
            await Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var uri = Service.URI + "api/Users/Avatar?userID=" + ID;
                    var result = await client.GetStringAsync(uri);
                    imageUri = JsonConvert.DeserializeObject<string>(result);
                }

            });

            return imageUri;
        }



    }
}
