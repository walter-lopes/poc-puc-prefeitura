using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGM_MVC.Models.Servidor;
using SGM_MVC.Services.Servidor;
using System.Collections.Generic;

namespace SGM_MVC.Controllers.PortalAdm.ServidorPublico
{
    public class ServidorPublicoController : Controller
    {
        private readonly FuncionarioServices funcionarioServices;

        public ServidorPublicoController() {
            funcionarioServices = new FuncionarioServices();
        }
        [ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            return View();
        }
       
        public IActionResult Funcionario()
        {
            return View("../Portal/ServidorPublico/Funcionario");
        }
        
        public IActionResult CadastrarFuncionario()
        {
            DepartamentoServices DepartamentoServices = new DepartamentoServices();
            List<Departamento> departamentos = DepartamentoServices.RetornaDepartamentos();

            List<SelectListItem> SelectListItemDepartamentos = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Selecione", Value = "" }
            };
            foreach (Departamento departamento in departamentos)
            {
                SelectListItemDepartamentos.Add(new SelectListItem() {Text = departamento.Nome, Value = departamento.Id.ToString() });
            }

            CargoServices CargoServices = new CargoServices();
            List<Cargo> Cargos = CargoServices.GetCargosItems();

            List<SelectListItem> SelectListItemCargos = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Selecione", Value = "" }
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
            ViewData["Message"] = funcionarioServices.Create(funcionario);
            return RedirectToAction("CadastrarFuncionario", "ServidorPublico");
        }

        [ValidateAntiForgeryToken]
        public IActionResult PesquisaFuncionario(string IdEmail)
        {
            Funcionario funcionario = funcionarioServices.PesquisaFuncionario(IdEmail);

            _ = funcionario == null ? ViewData["MessageError"] = $"Funcionário {IdEmail} não encontrado" : ViewData["MessageError"] = null;

            return View("../Portal/ServidorPublico/Funcionario", funcionario);
        }

        [ValidateAntiForgeryToken]
        public IActionResult Departamento()
        {
            DepartamentoServices ds = new DepartamentoServices();
            Departamento dp = new Departamento();
            string returnMessage = ds.InserirDepartamento(dp);
            ViewBag.ReturnMessage = returnMessage;
            return View("../Portal/ServidorPublico/Departamento", new Departamento());
        }
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarDepartamento()
        {
            return View("../Portal/ServidorPublico/CadastrarDepartamento");
        }
    }
}
