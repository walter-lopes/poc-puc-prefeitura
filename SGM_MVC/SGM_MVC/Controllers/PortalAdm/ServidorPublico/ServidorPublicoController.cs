using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGM_MVC.Models.Servidor;
using SGM_MVC.Services.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Controllers.PortalAdm.ServidorPublico
{
    public class ServidorPublicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Funcionario()
        {
            return View("../Portal/ServidorPublico/Funcionario", new Funcionario());
        }
        public IActionResult CadastrarFuncionario()
        {
            DepartamentoServices DepartamentoServices = new DepartamentoServices();
            List<Departamento> departamentos = DepartamentoServices.RetornaDepartamentos();

            List<SelectListItem> SelectListItemDepartamentos = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Selecione", Value = "-1" }
            };
            foreach (Departamento departamento in departamentos)
            {
                SelectListItemDepartamentos.Add(new SelectListItem() {Text = departamento.Nome, Value = departamento.Id.ToString() });
            }

            CargoServices CargoServices = new CargoServices();
            List<Cargo> Cargos = CargoServices.RetornaCargos();

            List<SelectListItem> SelectListItemCargos = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Selecione", Value = "-1" }
            };

            foreach (Cargo cargo in Cargos)
            {
                SelectListItemCargos.Add(new SelectListItem() {Text = cargo.Nome, Value = cargo.Nome });
            }

            ViewBag.DepartamentoList = SelectListItemDepartamentos; 
            ViewBag.CargoList = SelectListItemCargos;
            return View("../Portal/ServidorPublico/CadastrarFuncionario");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InserirFuncionario(Funcionario funcionario)
        {
            FuncionarioServices funcionarioServices = new FuncionarioServices();
            funcionarioServices.Create(funcionario);
            return RedirectToAction("CadastrarFuncionario", "ServidorPublico");
        }

        public IActionResult PesquisaFuncionario(string IdFuncionario)
        {
            FuncionarioServices funcionarioServices = new FuncionarioServices();
            Funcionario funcionario = funcionarioServices.PesquisaFuncionario(IdFuncionario);
            return View("../Portal/ServidorPublico/Funcionario", funcionario);
        }        

        public IActionResult Departamento()
        {
            DepartamentoServices ds = new DepartamentoServices();
            Departamento dp = new Departamento();
            string returnMessage = ds.InserirDepartamento(dp);
            ViewBag.ReturnMessage = returnMessage;
            return View("../Portal/ServidorPublico/Departamento", new Departamento());
        }
        public IActionResult CadastrarDepartamento()
        {
            return View("../Portal/ServidorPublico/CadastrarDepartamento");
        }
    }
}
