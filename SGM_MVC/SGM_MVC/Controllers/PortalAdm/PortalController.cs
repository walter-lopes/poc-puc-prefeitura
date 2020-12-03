using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SGM_MVC.Controllers.PortalAdm
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("token") == null)
                return RedirectToAction("Index", "Login");
            else
                return View();
        }
    }
}
