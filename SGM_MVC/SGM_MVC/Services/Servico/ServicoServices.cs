using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGM_MVC.Models.Cidadao;
using SGM_MVC.Models.Servico;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace SGM_MVC.Services.Servico
{
    public class ServicoServices
    {
        public string Name { get; set; }
        public double Budget { get; set; }
        public string Status { get; set; }
        public string RequesterName { get; set; }
        public string RequesterEmail { get; set; }
        public string RequesterPhone { get; set; }
        public List<Histories> Histories { get; set; }
        public string Date { get; set; }
        public string UpdateDate { get; set; }
        public string Codigo { get; set; }
        public string Id { get; set; }


        [HttpGet]
        public Protocol Protocolo(string IdServico)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44363/project/{IdServico}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = new HttpClient();
            var response = client.SendAsync(request).Result;
            _ = new Person();
            Protocol protocolo = null;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;

                var model = JsonConvert.DeserializeObject<ServicoServices>(responseString);

                if (model != null)
                {

                    protocolo = new Protocol();
                    Person pessoa = new Person();
                    Contact contato = new Contact();
                    List<Histories> statuses = new List<Histories>();

                    contato.Email = model.RequesterEmail;
                    contato.Phone = model.RequesterPhone;
                    pessoa.Name = model.RequesterName;
                    pessoa.Contact = contato;


                    if (model.Histories != null)
                    {
                        foreach (var item in model.Histories)
                        {
                            Histories status = new Histories
                            {
                                UpdateDate = item.UpdateDate,
                                Employee = item.Employee,
                                EmployeeMail = item.EmployeeMail,
                                Status = item.Status
                            };

                            statuses.Add(status);
                        }
                    }

                    protocolo.CreateDate = DateTime.Parse(model.Date);
                    protocolo.UpdateDate = DateTime.Parse(model.UpdateDate);
                    protocolo.Name = model.Name;
                    protocolo.Person = pessoa;
                    protocolo.History = statuses;
                    protocolo.Codigo = model.Codigo;
                    protocolo.Id = model.Id;

                }
            }
            return protocolo;
        }

        [HttpPost]
        public string Create(Protocol protocol)
        {
            List<Histories> tempHist = new List<Histories>();
            Histories histories = new Histories();
            histories.UpdateDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
            histories.Employee = protocol.Person.Name;
            //histories.EmployeeMail = protocol.Person.Contact.Email;
            histories.Status = "Criado";
            tempHist.Add(histories);

            ServicoServices services = new ServicoServices
            {

                Name = protocol.Name,
                //Id = "3da85f34-5717-4562-b3fc-2c963f66afa6",
                Histories = tempHist,
                Date = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                UpdateDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"),
                RequesterName = protocol.Person.Name,
                RequesterEmail = protocol.Person.Contact.Email,
                RequesterPhone = protocol.Person.Contact.Phone,
                Status = "Criado"
            };
            //services.Identifier = protocol.Person.Identifier;


            var projectJson = new StringContent(
                                JsonConvert.SerializeObject(services),
                                Encoding.UTF8,
                                "application/json");

            var client = new HttpClient();
            var response = client.PostAsync($"https://localhost:44383/project",
                                                  projectJson).Result;

            if (response.IsSuccessStatusCode)
            {
                var codigo = response.Content.ReadAsStringAsync().Result;

                return $"Protocolo Cadastrado: Código {codigo}";
            }
            else
            {
                return $"Erro ao cadastrar protocolo. {response.ReasonPhrase}";
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(Protocol protocol, string userLogged)
        {
 
            var client = new HttpClient();

            ChangeStatus status = new ChangeStatus()
            {
                EmployeeEmail = userLogged,
                Status = "Concluído"
            };

            var json = new StringContent(
                    JsonConvert.SerializeObject(status),
                    Encoding.UTF8,
                    "application/json");
            var id = protocol.Id;

            var response = await client.PutAsync($"https://localhost:44363/project/{id}", json);

            if (response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                return null;
            }
        }
    }
    public class ChangeStatus
    {
        public string EmployeeEmail { get; set; }
        public string Status { get; set; }
    }
}
