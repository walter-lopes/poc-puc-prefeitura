using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
            
        [HttpPost]
        public async Task<IActionResult> AutenticarAsync(String login, String password)
        {
            AutenticationServices aut = new AutenticationServices();
            _ = new ClaimsIdentity();

            try
            {
                HttpResponseMessage responseMessage = await aut.Autenticar(login, password);

                var customerJsonString = await responseMessage.Content.ReadAsStringAsync();
                if (responseMessage.IsSuccessStatusCode)
                {
                    var userJson = JsonConvert.DeserializeObject<User>(customerJsonString);

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, userJson.Name),
                        new Claim(ClaimTypes.NameIdentifier, userJson.Login),
                        new Claim(ClaimTypes.Role, userJson.Role),
                        new Claim(ClaimTypes.Rsa, userJson.Token)
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        //AllowRefresh = <bool>,
                        // Refreshing the authentication session should be allowed.

                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(5),
                        // The time at which the authentication ticket expires. A 
                        // value set here overrides the ExpireTimeSpan option of 
                        // CookieAuthenticationOptions set with AddCookie.

                        //IsPersistent = true,
                        // Whether the authentication session is persisted across 
                        // multiple requests. When used with cookies, controls
                        // whether the cookie's lifetime is absolute (matching the
                        // lifetime of the authentication ticket) or session-based.

                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToAction("Index", "Home");
                }
                else
                {   
                    ViewData["MessageError"] = customerJsonString;
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
