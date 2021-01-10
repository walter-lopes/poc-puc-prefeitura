using System;
using System.ComponentModel.DataAnnotations;

namespace SGM_MVC.Models.Cidadao.Servico
{
    public class Status
    {
        public string Situacao { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
        public string Responsavel { get; set; }
    }
}