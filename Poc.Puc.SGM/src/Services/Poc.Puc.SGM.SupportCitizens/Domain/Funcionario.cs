using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.SupportCitizens.Domain
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }
        public Departamento Departamento { get; set; }

        public string Cargo { get; set; }
        public string Email { get; set; }
        public DateTime DataDeAdmissao { get; set; }
    }

    public class Departamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataDeCadastro { get; set; }
    }
}
