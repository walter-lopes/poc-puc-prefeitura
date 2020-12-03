using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGM_MVC.Models.Cidadao;
using SGM_MVC.Services.Cidadao;
using SGM_MVC.Services.Cidadao.Servico;

namespace SGM_MVC.Controllers.Cidadao
{
    public class CidadaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IptuItr()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PesquisaIptuItr(int CpfCnpj)
        {
            CidadaoServices cidadao = new CidadaoServices();            
            return View(cidadao.retornaDadosCidadao(CpfCnpj));
        }

        public IActionResult Servico()
        {
            return View();
        }

        public IActionResult PesquisaServico(int ProtocoloIdServico)
        {
            ServicoServices servico = new ServicoServices();
            return View(servico.retornaDadosServico(ProtocoloIdServico));
        }

    }
}
