using System;
using System.Collections.Generic;
using System.Text;

namespace ZakupowoMobile.Models
{
    class LoginBindingModel
    {
        public static User user;

        public string Login
        {
            get; set;
        }
    
        public string Password
        {
            get; set;
        }
        
    }
}
