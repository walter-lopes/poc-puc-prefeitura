using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGM_MVC.Models.Servico;
using SGM_MVC.Services.Servico;
using System.Collections.Generic;

namespace SGM_MVC.Controllers.PortalAdm
{
    public class PortalController : Controller
    {

        private readonly ServicoServices servico;

        public PortalController() { 
            servico = new ServicoServices();
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Servicos()
        {
            return View();
        }

        [Authorize]
        public IActionResult PesquisaProtocolo()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult AtualizaProtocolo(Protocol protocol)
        {
            servico.Put(protocol, HttpContext.User.Identity.Name);

            return RedirectToAction("ListaProtocolos","Portal", new { ProtocoloIdServico = protocol.Codigo });
        }

        [Authorize]
        public IActionResult ListaProtocolos(string ProtocoloIdServico)
        {
            Protocol protocol = servico.Protocolo(ProtocoloIdServico);
            _ = protocol == null ? ViewData["MessageError"] = $"Protocolo {ProtocoloIdServico} não encontrado" : ViewData["MessageError"] = null;
            return protocol == null ? View("PesquisaProtocolo") : View(protocol);
        }

        [Authorize]
        public IActionResult CadastrarProtocolo() {
            List<SelectListItem> SelectListItemSolicitacoes = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Selecione", Value = "-1" },
                new SelectListItem() { Text = "Poda de Árvores", Value = "Poda de Árvores" },
                new SelectListItem() { Text = "Isenção de IPTU", Value = "Isenção de IPTU" },
                new SelectListItem() { Text = "Matrícula Escolar", Value = "Matrícula Escolar" }
            };

            ViewBag.Name = SelectListItemSolicitacoes;

            return View(new Protocol());
        }

        [Authorize]
        public IActionResult InserirProtocolo(Protocol protocol)
        {
            //ViewBag.ReturnMessage = servico.Create(protocol);
            ViewData["ReturnMessage"] = servico.Create(protocol);
            return View("PesquisaProtocolo", new Protocol());
        }

        [Authorize]
        public IActionResult Manutencao()
        {
            return View("ServidorPublico/Index");
        }
    }
}
