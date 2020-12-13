using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using SGM_MVC.Models.Authentication;
using SGM_MVC.Services;

namespace SGM_MVC.Controllers.Authentication
{
    public class Login : Controller
    {
        public User UserLog { get; set; } = new User();
        public IActionResult Index()
        {
            UserLog.Id = "";
            return View(UserLog);
        }

        [HttpPost]
        public async Task<IActionResult> AutenticarAsync(String login, String password)
        {
            AutenticationServices aut = new AutenticationServices();           

            try
            {
                HttpResponseMessage responseMessage = await aut.Autenticar(login, password);
                var customerJsonString = await responseMessage.Content.ReadAsStringAsync();
                if (responseMessage.IsSuccessStatusCode)
                {
                    var userJson = JObject.Parse(customerJsonString).SelectToken("user");
                    UserLog.Id = userJson.SelectToken("id").ToString();
                    UserLog.Login = userJson.SelectToken("login").ToString();
                    UserLog.Role = userJson.SelectToken("role").ToString();
                    UserLog.Name = userJson.SelectToken("name").ToString();
                    HttpContext.Session.SetString("token", JObject.Parse(customerJsonString).SelectToken("token").ToString());

                    return RedirectToAction("Index", "Portal");
                }
                else
                {
                    
                    string message = JObject.Parse(customerJsonString)["message"].ToString();
                    ViewData["MessageError"] = message;
                    return View("Index", UserLog);
                }
            }
            catch (Exception e)
            {
                ViewData["MessageError"] = e.Message;
                return View("Index", UserLog);
            }
        }
    }
}
