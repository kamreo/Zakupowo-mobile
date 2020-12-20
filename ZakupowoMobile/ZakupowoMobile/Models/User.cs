using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
        }

        public int ID
        {
            get;
            set;
        }

        public string GetFullName()
        {
            return "";
        }


        public async Task<string> GetProfilePictureAsync()
        {
            var imageUri = "";
            await Task.Run(async () =>
            {
                using (var client = new HttpClient())
                {
                    var uri = Service.URI + "api/Users/Avatar?userID=" + this.ID;
                    var result = await client.GetStringAsync(uri);

                    imageUri = result;

                }

            });
            return imageUri;

        }



    }
}
