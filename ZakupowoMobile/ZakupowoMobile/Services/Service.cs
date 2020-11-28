using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ZakupowoMobile.Services
{
    class Service
    {
        public static async Task<bool> RegisterUserAsync(string login, string email, string password, string firstname, string lastname, string birthdate)
        {
            bool Response = false;
            await Task.Run(()=>
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
                var response = client.PostAsync("https://25.106.6.168:45455/" + "api/Users/Register", httpContent);


                if (response.Result.IsSuccessStatusCode)
                {
                    Response = true;
                }


            });
            return Response;
        }
    }
}
