using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Servidor
{
    public class Funcionario
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }
        public Departamento Departamento { get; set; }

        public string Cargo { get; set; }
        public string Email { get; set; }
        public DateTime DataDeAdmissao { get; set; }
    }
}
