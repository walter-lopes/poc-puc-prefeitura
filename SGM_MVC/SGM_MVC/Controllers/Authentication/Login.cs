using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGM_MVC.Services;

namespace SGM_MVC.Controllers.Authentication
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AutenticarAsync(String login, String password)
        {
            AutenticationServices aut = new AutenticationServices();

            return await aut.Autenticar(login, password) ? View("Autenticado") : View();
        }
    }
}
