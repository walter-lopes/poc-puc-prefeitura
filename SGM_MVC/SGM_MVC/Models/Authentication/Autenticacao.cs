using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Authentication
{
    public class Autenticacao
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
