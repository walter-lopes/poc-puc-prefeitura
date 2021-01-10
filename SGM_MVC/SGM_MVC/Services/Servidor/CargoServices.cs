using SGM_MVC.Models.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Services.Servidor
{
    public class CargoServices
    {
        public List<Cargo> GetCargosItems()
        {
            List<Cargo> cargos = new List<Cargo>();

            List<string> nomeCargos = GetNomeCargos();

            int i = 1;
            foreach (var item in nomeCargos)
            {
                cargos.Add(new Cargo(++i, item));
            }
     
            return cargos;
        }

        private List<string> GetNomeCargos()
        {
            List<string> nomeCargos = new List<string>
            {
                "Recursos Humanos",
                "Auxiliar Administrativo",
                "Auxiliar Administrativo Escolar",
                "Engenheiro Civil",
                "Engenheiro Agrônomo",
                "Fiscal",
                "Técnico em Contabilidade",
                "Tesoureiro",
                "Diretor de Departamento",
                "Subprefeito",
                "Prefeito",
                "Secretário Municipal",
                "Vereador",
                "Professor"
            };
            nomeCargos.Sort();

            return nomeCargos;
        }
    }
}
