using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Cidadao.Servico
{
    public class Protocolo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Status> HistoricoStatus { get; set; }
        public DateTime DataDeRegistro { get; set; }

    }
}
