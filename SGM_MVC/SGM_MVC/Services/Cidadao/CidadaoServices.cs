using SGM_MVC.Models.Cidadao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGM_MVC.Services.Cidadao
{
    public class CidadaoServices
    {
        public Pessoa retornaDadosCidadao(int CpfCnpj)
        {
            Pessoa cidadao = new Pessoa();
            cidadao.Nome = "Francisco da Silva";
            cidadao.CpfCnpj = CpfCnpj;

            Imovel imovel = new Imovel();
            imovel.TipoImovel = "Casa";
            imovel.TipoImposto = "IPTU";

            Endereco endereco = new Endereco();
            endereco.Rua = "Av. Paulista";
            endereco.Numero = 100;
            endereco.Cep = 09990000;
            endereco.Cidade = "São Paulo";
            endereco.Estado = "São Paulo";
            imovel.Endereco = endereco;
            cidadao.Imovel = imovel;

            return cidadao;
        }
    }
}
