using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Cidadao
{
    public class Pessoa
    {
        public String Nome { get; set; }
        public int CpfCnpj { get; set; }
        public Imovel Imovel { get; set; }
    }
}
