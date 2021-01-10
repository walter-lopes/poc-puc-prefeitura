using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Servidor
{
    public class Funcionario
    {
        public string Id { get; set; }
        public string Nome { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }
        public string Cargo { get; set; }
        public string Email { get; set; }
    }
}
