using Microsoft.AspNetCore.Mvc;
using SGM_MVC.Models.Servico;
using SGM_MVC.Services.Servico;

namespace SGM_MVC.Controllers.PortalAdm
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            //if (HttpContext.Session.GetString("token") == null)
            //    return RedirectToAction("Index", "Login");
            //else
                return View();
        }
        public IActionResult Servicos()
        {
            //if (HttpContext.Session.GetString("token") == null)
            //    return RedirectToAction("Index", "Login");
            //else
            return View();
        }

        public IActionResult PesquisaProtocolo()
        {
            //if (HttpContext.Session.GetString("token") == null)
            //    return RedirectToAction("Index", "Login");
            //else
            return View();
        }

        public IActionResult ListaProtocolos(string ProtocoloIdServico)
        {
            //if (HttpContext.Session.GetString("token") == null)
            //    return RedirectToAction("Index", "Login");
            //else
            ServicoServices servico = new ServicoServices();
            Protocol protocol = servico.Protocolo(ProtocoloIdServico);
            return protocol == null ? View("") : View(protocol);
        }

        public IActionResult CadastrarProtocolo() {
            return View(new Protocol());
        }

        public IActionResult InserirProtocolo(Protocol protocol)
        {
            ServicoServices servico = new ServicoServices();
            ViewBag.ReturnMessage = servico.Create(protocol);
            return View("CadastrarProtocolo", new Protocol());
        }

        public IActionResult Manutencao()
        {
            return View("ServidorPublico/Index");
        }
    }
}
