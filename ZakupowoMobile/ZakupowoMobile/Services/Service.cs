using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZakupowoMobile.Models;
using ZakupowoMobile.Views;

namespace ZakupowoMobile.Services
{

    
    public class Service
    {
        public static string URI = "http://192.168.0.146:45455/";
        public static async Task<bool> LoginUserAsync(string login, string password)
        {
            bool Response = false;
            await Task.Run(async () =>
            {
                var client = new HttpClient();
                var model = new LoginBindingModel
                {
                    Login = login,
                    Password = password,
                };

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await client.PostAsync(URI + "api/Users/Login", httpContent);
                var user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);

                if (response.IsSuccessStatusCode)
                {
                
                    Session.user = user;
                    Response = true;
                }


            });
            return Response;
        }


        public static async Task<bool> RegisterUserAsync(string login, string email, string password, string firstname, string lastname, string birthdate)
        {
            bool Response = false;
            await Task.Run(() =>
            {
                var client = new HttpClient();
                var model = new Models.RegisterBindingModel
                {
                    Login = login,
                    Email = email,
                    Password = password,
                    FirstName = firstname,
                    LastName = lastname,
                    BirthDate = birthdate

                };

                var json = JsonConvert.SerializeObject(model);
                HttpContent httpContent = new StringContent(json);
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = client.PostAsync(URI + "api/Users/Register", httpContent);


                if (response.Result.IsSuccessStatusCode)
                {
                    Response = true;
                }


            });
            return Response;
        }
       
    }
}
