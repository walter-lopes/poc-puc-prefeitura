using SGM_MVC.Models.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Services.Servidor
{
    public class DepartamentoServices
    {
        public List<Departamento> RetornaDepartamentos()
        {
            Departamento departamento = new Departamento();
            Departamento departamento1 = new Departamento();
            Departamento departamento2 = new Departamento();
            Departamento departamento3 = new Departamento();

            List<Departamento> departamentos = new List<Departamento>();

            departamento.Nome = "Transportes";
            departamento.DataDeCadastro = DateTime.Now;
            departamento.Descricao = "Departamento Municipal de Transporte";
            departamento.Id = 1;
            departamentos.Add(departamento);

            departamento1.Nome = "Tesouraria";
            departamento1.DataDeCadastro = DateTime.Now;
            departamento1.Descricao = "Departamento Municipal de Tesouraria";
            departamento1.Id = 2;
            departamentos.Add(departamento1);

            departamento2.Nome = "Educação";
            departamento2.DataDeCadastro = DateTime.Now;
            departamento2.Descricao = "Departamento Municipal de Educação";
            departamento2.Id = 3;
            departamentos.Add(departamento2);

            departamento3.Nome = "Financeiro";
            departamento3.DataDeCadastro = DateTime.Now;
            departamento3.Descricao = "Financeiro";
            departamento3.Id = 4;
            departamentos.Add(departamento3);

            return departamentos;
        }

        public string InserirDepartamento(Departamento departamento)
        {
            return "";
        }
    }
}
