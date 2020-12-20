using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44363/employees/{email}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = new HttpClient();
            var response = client.SendAsync(request).Result;
            _ = new Person();

            string responseString = response.Content.ReadAsStringAsync().Result;

            var model = JsonConvert.DeserializeObject<Funcionario>(responseString);


            Funcionario funcionario = new Funcionario();
          

            if (response.IsSuccessStatusCode)
            {
                //Departamento departamento = new Departamento
                //{
                //    Nome = "Transportes",
                //    DataDeCadastro = DateTime.Now,
                //    Descricao = "Departamento Municipal de Transporte",
                //    Id = 1
                //};
                funcionario.Id = model.Id;
                funcionario.Nome = model.Nome;
                //funcionario.Cargo = "Professor";
                //funcionario.Email = "rodrigo@bomsucesso.gov.br";
                //funcionario.DataDeAdmissao = DateTime.Parse("2010/10/11");
                //funcionario.DataNascimento = DateTime.Parse("1985/01/22");
                funcionario.Cargo = model.Cargo;
                funcionario.Email = model.Email;
                funcionario.DataNascimento = model.DataNascimento;

            }
            return funcionario;
        }

        [HttpPost]
        public string Create(Funcionario func)
        {
            //_ = new Funcionario
            //{
            //    Id = func.Id,
            //    Nome = func.Nome,
            //    Cargo = func.Cargo,
            //    DataDeAdmissao = func.DataDeAdmissao,
            //    DataNascimento = func.DataNascimento,
            //    Departamento = func.Departamento,
            //    Email = func.Email
            //};

            var json = JsonConvert.SerializeObject(func);
            JObject jObject = JObject.Parse(json);

            jObject.Property("Id").Remove();
            json = jObject.ToString();

            var projectJson = new StringContent(
                                json,
                                Encoding.UTF8,
                                "application/json");

            var client = new HttpClient();
            var response = client.PostAsync($"https://localhost:44363/employees",
                                                  projectJson).Result;

            if (response.IsSuccessStatusCode)
            {
                return "Funcionário Cadastrado";
            }
            else
            {
                return $"Erro ao cadastrar funcionário. {response.ReasonPhrase}";
            }
        }
    }
}
