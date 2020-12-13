using Newtonsoft.Json;
using SGM_MVC.Models.Cidadao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGM_MVC.Services.Cidadao
{

    public class CitizenServices
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Identifier { get; set; }

        public decimal Tax { get; set; }

        public string Zone { get; set; }

        public decimal Fee { get; set; }

        public Address Address { get; set; }
        public string  Kind { get; set; }

        public string  KindOfFee { get; set; }

        public Person RetornaDadosCidadao(string CpfCnpj)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44383/citizen/support/{CpfCnpj}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = new HttpClient();
            var response = client.SendAsync(request).Result;

            Person cidadao = new Person();

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;

                var model = JsonConvert.DeserializeObject<CitizenServices>(responseString);
                
                if(model != null)
                {

                    cidadao.Name = model.FirstName + " " + model.LastName;
                    cidadao.Identifier = CpfCnpj;

                    Property imovel = new Property
                    {
                        Kind = model.Kind,
                        KindOfFee = model.KindOfFee,
                        FeeValue = model.Tax * model.Fee,
                        Zone = model.Zone
                    };
                    
                    imovel.Address = model.Address;
                    cidadao.Property = imovel;
                }
            }
            return cidadao;
        }
    }
}
