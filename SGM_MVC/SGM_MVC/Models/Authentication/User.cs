using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Authentication
{
    public class User
    {
        public string Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
