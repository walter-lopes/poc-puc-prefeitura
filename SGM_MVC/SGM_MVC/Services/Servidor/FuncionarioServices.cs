using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SGM_MVC.Models.Authentication;
using SGM_MVC.Models.Cidadao;
using SGM_MVC.Models.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SGM_MVC.Services.Servidor
{
    public class FuncionarioServices
    {

        public Funcionario PesquisaFuncionario(string email){

            var request = new HttpRequestMessage(HttpMethod.Get, Settings.HostApiGateWay + $"employee/{email}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = new HttpClient();
            var response = client.SendAsync(request).Result;
            _ = new Person();

            string responseString = response.Content.ReadAsStringAsync().Result;

            var model = JsonConvert.DeserializeObject<Funcionario>(responseString);

            Funcionario funcionario = null;          

            if (response.IsSuccessStatusCode)
            {
                if (model != null)
                {
                    funcionario = new Funcionario
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        Cargo = model.Cargo,
                        Email = model.Email,
                        DataNascimento = model.DataNascimento
                    };
                }         

            }
            return funcionario;
        }

        [HttpPost]
        public string Create(Funcionario func)
        {
            
            var json = JsonConvert.SerializeObject(func);
            JObject jObject = JObject.Parse(json);

            jObject.Property("Id").Remove();
            json = jObject.ToString();

            var projectJson = new StringContent(
                                json,
                                Encoding.UTF8,
                                "application/json");

            var client = new HttpClient();
            HttpResponseMessage response = client.PostAsync(Settings.HostApiGateWay + $"employee",
                                                  projectJson).Result;

            if (response.IsSuccessStatusCode)
            {
                AutenticationServices aut = new AutenticationServices();
                response = aut.GenerateUserPass(func);
                if (response.IsSuccessStatusCode)
                {
                    return "Funcionário Cadastrado";
                }
                else
                {
                    return $"Erro ao cadastrar funcionário. {response.ReasonPhrase}";
                }
            }
            else
            {
                return $"Erro ao cadastrar funcionário. {response.ReasonPhrase}";
            }
        }
    }
}
