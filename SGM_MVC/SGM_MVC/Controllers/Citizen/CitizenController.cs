using Microsoft.AspNetCore.Mvc;
using SGM_MVC.Models.Servico;
using SGM_MVC.Services.Cidadao;
using SGM_MVC.Services.Servico;

namespace SGM_MVC.Controllers.Cidadao
{
    public class CitizenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IptuItr()
        {
            return View();
        }

        public IActionResult PesquisaIptuItr(string CpfCnpj)
        {
            CitizenServices cidadao = new CitizenServices();
            return View(cidadao.RetornaDadosCidadao(CpfCnpj));
        }

        public IActionResult Servico()
        {
            return View();
        }

        public IActionResult PesquisaServico(string ProtocoloIdServico)
        {
            ServicoServices servico = new ServicoServices();
            Protocol protocol = servico.Protocolo(ProtocoloIdServico);
            _ = protocol == null ? ViewData["MessageError"] = $"Protocolo {ProtocoloIdServico} não encontrado" : ViewData["MessageError"] = null;
            return protocol == null ? View("Servico") : View(protocol);
        }

    }
}
