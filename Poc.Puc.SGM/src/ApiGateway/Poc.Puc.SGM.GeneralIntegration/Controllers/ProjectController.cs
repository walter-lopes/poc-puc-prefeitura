using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Poc.Puc.SGM.GeneralIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.GeneralIntegration.Controllers
{
    [Route("project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProjectController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectModel project)
        {
            var json = JsonConvert.SerializeObject(project);
            JObject jObject = JObject.Parse(json);
            jObject.Property("Id").Remove();
            json = jObject.ToString();

            var projectJson = new StringContent(
                                json,
                                Encoding.UTF8,
                                "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:44363/project", projectJson);

            if (response.IsSuccessStatusCode)
            {
                var codigo = response.Content.ReadAsStringAsync().Result;

                return Ok(codigo);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, ChangeStatusRequest request)
        {
            var json = new StringContent(
                                JsonConvert.SerializeObject(request),
                                Encoding.UTF8,
                                "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PutAsync($"https://localhost:44363/project/{id}", json);

            if (response.IsSuccessStatusCode)
            {
               
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44363/project");

            if (response.IsSuccessStatusCode)
            {
                return Ok(response.Content);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get([FromRoute] string codigo)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:44363/project/{codigo}");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                return Ok(JsonConvert.DeserializeObject<CreateProjectModel>(responseString));
            }
            else
            {
                return BadRequest();
            }
        }
    }


    public class ChangeStatusRequest
    {
        public string EmployeeEmail { get; set; }

        public string Status { get; set; }
    }
}
