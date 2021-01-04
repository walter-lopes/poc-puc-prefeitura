using SGM_MVC.Models.Cidadao;
using SGM_MVC.Models.Servidor;
using System;
using System.Collections.Generic;
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
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Codigo { get; set; }

        public Protocol() {
            this.CreateDate = DateTime.Now;
        }
    }
}
