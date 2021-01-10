using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Servidor
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Cargo() { }

        public Cargo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }
}
