using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Poc.Puc.SGM.GeneralIntegration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.GeneralIntegration.Controllers
{
    [Route("citizen/support")]
    [ApiController]
    public class CitizenSupportController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public CitizenSupportController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> GetByIdentifier([FromRoute] string identifier)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44363/citizen/support/{identifier}");

            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();

                return Ok(JsonConvert.DeserializeObject<CitizenModel>(responseString));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
