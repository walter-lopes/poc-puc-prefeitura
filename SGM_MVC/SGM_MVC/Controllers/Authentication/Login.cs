using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGM_MVC.Models.Authentication;
using SGM_MVC.Services;

namespace SGM_MVC.Controllers.Authentication
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            User user = new User();
            user.Id = "";
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> AutenticarAsync(String login, String password)
        {
            AutenticationServices aut = new AutenticationServices();
            
            try
            {
                HttpResponseMessage responseMessage = await aut.Autenticar(login, password);
                return responseMessage.IsSuccessStatusCode ? View("Autenticado") : View();
            }
            catch (Exception e)
            {
                ViewData["MessageError"] = e.Message;
                return View("Index",new User());
            }
        }
    }
}
