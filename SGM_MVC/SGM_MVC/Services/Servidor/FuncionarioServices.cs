using Newtonsoft.Json;
using SGM_MVC.Models.Cidadao;
using SGM_MVC.Models.Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SGM_MVC.Services.Servidor
{
    public class FuncionarioServices
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Funcionario PesquisaFuncionario(string matricula){

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44363/employee/{matricula}");

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
                Departamento departamento = new Departamento
                {
                    Nome = "Transportes",
                    DataDeCadastro = DateTime.Now,
                    Descricao = "Departamento Municipal de Transporte",
                    Id = 1
                };


                funcionario.Id = model.Id;
                funcionario.Nome = model.Nome;
                funcionario.Cargo = "Professor";
                funcionario.Email = "rodrigo@bomsucesso.gov.br";
                funcionario.DataDeAdmissao = DateTime.Parse("2010/10/11");
                funcionario.DataNascimento = DateTime.Parse("1985/01/22");
                funcionario.Departamento = departamento;

            }
            return funcionario;
        }

        public string InserirFuncionario(Funcionario func)
        {
            _ = new Funcionario
            {
                Id = func.Id,
                Nome = func.Nome,
                Cargo = func.Cargo,
                DataDeAdmissao = func.DataDeAdmissao,
                DataNascimento = func.DataNascimento,
                Departamento = func.Departamento,
                Email = func.Email
            };

            return "";
        }
    }
}
