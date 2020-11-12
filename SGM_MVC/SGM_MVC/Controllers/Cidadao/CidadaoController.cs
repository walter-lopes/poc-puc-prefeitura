using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGM_MVC.Models.Cidadao;

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

        public IActionResult Protocolo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PesquisaIptuItr(int CpfCnpj)
        {
            Pessoa cidadao = new Pessoa();
            cidadao.Nome = "Francisco da Silva";
            cidadao.CpfCnpj = CpfCnpj;

            Imovel imovel = new Imovel();
            imovel.TipoImovel = "Casa";
            imovel.TipoImposto = "IPTU";

            Endereco endereco = new Endereco();
            endereco.Rua = "Av. Paulista";
            endereco.Numero = 100;
            endereco.Cep = 09990000;
            endereco.Cidade = "São Paulo";
            endereco.Estado = "São Paulo";
            imovel.Endereco = endereco;
            cidadao.Imovel = imovel;
            return View(cidadao);
        }

    }
}
