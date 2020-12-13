using SGM_MVC.Models.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Services.Servidor
{
    public class CargoServices
    {
        public List<Cargo> RetornaCargos()
        {
            Cargo cargo = new Cargo();
            Cargo cargo1 = new Cargo();
            Cargo cargo2 = new Cargo();
            Cargo cargo3 = new Cargo();

            List<Cargo> cargos = new List<Cargo>();

            cargo.Nome = "Assistênte Financeiro";
            cargo.Id = 1;
            cargos.Add(cargo);

            cargo1.Nome = "Secretário";
            cargo1.Id = 2;
            cargos.Add(cargo1);

            cargo2.Nome = "Contador";
            cargo2.Id = 3;
            cargos.Add(cargo2);

            cargo3.Nome = "Professor";
            cargo3.Id = 4;
            cargos.Add(cargo3);

            return cargos;
        }
    }
}
