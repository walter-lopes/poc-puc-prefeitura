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
    [Route("employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public EmployeeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Funcionario emp)
        {
            //var json = new StringContent(
            //                   JsonConvert.SerializeObject(emp),
            //                   Encoding.UTF8,
            //                   "application/json");

            var json = JsonConvert.SerializeObject(emp);
            JObject jObject = JObject.Parse(json);

            jObject.Property("Id").Remove();
            json = jObject.ToString();

            var projectJson = new StringContent(
                                json,
                                Encoding.UTF8,
                                "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PostAsync($"https://localhost:44363/employee", projectJson);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Funcionario emp)
        {
            var json = new StringContent(
                               JsonConvert.SerializeObject(emp),
                               Encoding.UTF8,
                               "application/json");

            var client = _clientFactory.CreateClient();
            var response = await client.PutAsync($"https://localhost:44363/employee/{id}", json);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get([FromRoute] string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44363/employee/{email}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                return Ok(JsonConvert.DeserializeObject<Funcionario>(responseString));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
