using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SGM_MVC.Models.Cidadao;
using SGM_MVC.Models.Servico;
using SGM_MVC.Services.ServicesUtils;
using SGM_MVC.SiteUtils;
using Newtonsoft.Json.Linq;

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
            var request = new HttpRequestMessage(HttpMethod.Get, Settings.HostApiGateWay + $"project/{IdServico}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = new HttpClient();
            var response = client.SendAsync(request).Result;
            _ = new Person();

            Protocol protocolo = null;

            if (response.IsSuccessStatusCode)
            {
                string responseString = response.Content.ReadAsStringAsync().Result;

                ServicoServices model = JsonConvert.DeserializeObject<ServicoServices>(responseString);

                if (model != null)
                {
                    Contact contato = GetContact(model);
                    Person pessoa = GetPerson(model, contato);
                    List<Histories> statuses = GetHistories(model);
                    protocolo = GetProtocolo(model, pessoa, statuses);
                }
            }
            return protocolo;
        }

        private static Person GetPerson(ServicoServices model, Contact contato)
        {
            return new Person
            {
                Name = model.RequesterName,
                Contact = contato
            };
        }

        private static Contact GetContact(ServicoServices model)
        {
            return new Contact
            {
                Email = model.RequesterEmail,
                Phone = model.RequesterPhone
            };
        }

        private static List<Histories> GetHistories(ServicoServices model)
        {
            List<Histories> statuses = new List<Histories>();
            if (model.Histories != null)
            {
                foreach (var item in model.Histories)
                {
                    Histories status = new Histories
                    {
                        UpdateDate = Formatacao.StringDateFormat(item.UpdateDate, "g"),
                        Employee = item.Employee,
                        EmployeeMail = item.EmployeeMail,
                        Status = item.Status
                    };

                    statuses.Add(status);
                }
            }

            return statuses;
        }

        private static Protocol GetProtocolo(ServicoServices model, Person pessoa, List<Histories> statuses)
        {
            Protocol protocolo = new Protocol
            {
                CreateDate = Formatacao.StringDateToDate(model.Date),
                UpdateDate = Formatacao.StringDateToDate(model.UpdateDate),
                Name = model.Name,
                Person = pessoa,
                History = statuses,
                Codigo = model.Codigo,
                Id = model.Id
            };
            return protocolo;
        }

        [HttpPost]
        public string Create(Protocol protocol)
        {
            List<Histories> tempHist = new List<Histories>();
            Histories histories = new Histories
            {
                UpdateDate = DateTime.Now.ToString("g"),
                Employee = protocol.Person.Name,
                //histories.EmployeeMail = protocol.Person.Contact.Email;
                Status = "Criado"
            };
            tempHist.Add(histories);

            ServicoServices services = new ServicoServices
            {
                Name = protocol.Name,
                //Id = "3da85f34-5717-4562-b3fc-2c963f66afa6",
                Histories = tempHist,
                Date = DateTime.Now.ToString("g"),
                UpdateDate = DateTime.Now.ToString("g"),
                RequesterName = protocol.Person.Name,
                RequesterEmail = protocol.Person.Contact.Email,
                RequesterPhone = protocol.Person.Contact.Phone,
                Status = "Criado"
            };

            var client = new HttpClient();


            var json = JsonConvert.SerializeObject(services);
            JObject jObject = JObject.Parse(json);
            jObject.Property("Id").Remove();
            json = jObject.ToString();
            var projectJson = new StringContent(
                                json,
                                Encoding.UTF8,
                                "application/json");

            var response = client.PostAsync(Settings.HostApiGateWay + $"project", projectJson).Result;

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
        public IActionResult Put(string id, string status, string userLogged)
        {

            var client = new HttpClient();

            ChangeStatus statusChange = new ChangeStatus()
            {
                EmployeeEmail = userLogged,
                Status = status
            };

            var response = client.PutAsync(Settings.HostApiGateWay + $"project/{id}", Utils.getJsonStringContent(statusChange)).Result;

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
