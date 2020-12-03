using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SGM_MVC.Models.Cidadao.Servico;

namespace SGM_MVC.Services.Cidadao.Servico
{
    public class ServicoServices
    {
        public Protocolo retornaDadosServico(int IdServico)
        {
            Protocolo protocolo = new Protocolo();
            List<Status> statuses = new List<Status>();
            Status status = new Status();
            Status status2 = new Status();

            status.Situacao = "Aberto";
            status.Data = DateTime.Now;
            status.Responsavel = "Cidadão";
            statuses.Add(status);

            status2.Situacao = "Em tratamento";
            status2.Data = DateTime.Now;
            status2.Responsavel = "Tesouraria";
            statuses.Add(status2);

            protocolo.DataDeRegistro = DateTime.Now;
            protocolo.Id = 1;
            protocolo.Nome = "Isenção de IPTU";
            protocolo.HistoricoStatus = statuses;
            
            return protocolo;
        }
    }
}
