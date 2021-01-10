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
            servico.Put(protocol.Id, protocol.Status, HttpContext.User.Identity.Name);

            return RedirectToAction("ListaProtocolos","Portal", new { ProtocoloIdServico = protocol.Codigo });
        }

        [HttpGet]
        [Authorize]
        public IActionResult ListaProtocolos(string ProtocoloIdServico)
        {
            Protocol protocol = new Protocol();
            
            protocol = servico.Protocolo(ProtocoloIdServico);
            
            _ = protocol == null ? ViewData["MessageError"] = $"Protocolo {ProtocoloIdServico} não encontrado" : ViewData["MessageError"] = null;

            ViewBag.Status = GetStatusViewBag();

            Dictionary<string, string> DeParaRole = GetDeParaRoleSolicitacao();
            ViewBag.Role = "";
            foreach (KeyValuePair<string, string> item in DeParaRole)
            {
                if (protocol.Name == item.Key) {
                    ViewBag.Role = item.Value;
                    break;
                }
            }            
            
            return protocol == null ? View("PesquisaProtocolo") : View(protocol);
        }

        [Authorize]
        public IActionResult CadastrarProtocolo() {
         
            ViewBag.Name = GetRequestedServices();

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

        private List<SelectListItem> GetStatusViewBag() {
            List<SelectListItem> SelectListStatus = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Selecione um Status", Value = "" },
                new SelectListItem() { Text = "Em Andamento", Value = "Em Andamento" },
                new SelectListItem() { Text = "Concluído", Value = "Concluído" }
            };

            return SelectListStatus;
        }

        private List<SelectListItem> GetRequestedServices() {
            
            List<SelectListItem> SelectListItemSolicitacoes = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Selecione", Value = "" },
                new SelectListItem() { Text = "Poda de Árvores", Value = "Poda de Árvores" },
                new SelectListItem() { Text = "Isenção de IPTU", Value = "Isenção de IPTU" },
                new SelectListItem() { Text = "Matrícula Escolar", Value = "Matrícula Escolar" }
            };

            return SelectListItemSolicitacoes;
        }

        private Dictionary<string, string> GetDeParaRoleSolicitacao() {

            Dictionary<string, string> retorno = new Dictionary<string, string>
            {
                { "Isenção de IPTU", "Técnico em Contabilidade" },
                { "Poda de Árvores", "Auxiliar Administrativo" },
                { "Matrícula Escolar", "Auxiliar Administrativo Escolar" }
            };

            return retorno;        
        }
    }
}
