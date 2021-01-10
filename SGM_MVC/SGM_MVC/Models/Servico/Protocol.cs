using Microsoft.AspNetCore.Mvc.Rendering;
using SGM_MVC.Models.Cidadao;
using SGM_MVC.Models.Servidor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Models.Servico
{
    public class Protocol
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Person Person { get; set; }
        public List<Histories> History { get; set; }
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime CreateDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime UpdateDate { get; set; }
        public string Codigo { get; set; }
        public string Status { get; set; }
        public Protocol() {
            this.CreateDate = DateTime.Now;       
        }
    }
}
