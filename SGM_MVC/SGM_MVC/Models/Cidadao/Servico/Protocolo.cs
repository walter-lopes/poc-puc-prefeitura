using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Cidadao.Servico
{
    public class Protocolo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Status> HistoricoStatus { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataDeRegistro { get; set; }
    }
}
