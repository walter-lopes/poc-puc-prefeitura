using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Poc.Puc.SGM.GeneralIntegration.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.GeneralIntegration.Controllers
{
    [Route("account")]
    [ApiController]
    public class AuthenticationController:ControllerBase
    {

        private readonly IHttpClientFactory _clientFactory;

        public AuthenticationController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] Autentication model)
        {
            var jsonContent = JsonConvert.SerializeObject(model);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = _clientFactory.CreateClient();
            try
            {
                HttpResponseMessage responseMessage = await client.PostAsync($"https://localhost:44359/v1/account/login", contentString);
                string responseString = await responseMessage.Content.ReadAsStringAsync();
                if (responseMessage.IsSuccessStatusCode)
                {
                    return Ok(JsonConvert.DeserializeObject<User>(responseString));
                }
                else
                {
                    return BadRequest(JObject.Parse(responseString)["message"].ToString());
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Post([FromBody] User model)
        {
            var jsonContent = JsonConvert.SerializeObject(model);

            JObject jObject = JObject.Parse(jsonContent);

            jObject.Property("Id").Remove();
            jObject.Property("Token").Remove();
            jsonContent = jObject.ToString();

            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpClient client = _clientFactory.CreateClient();
            try
            {
                HttpResponseMessage responseMessage = await client.PostAsync($"https://localhost:44359/v1/account", contentString);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string responseString = await responseMessage.Content.ReadAsStringAsync();

                    return Ok(responseString);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }


        public class Autentication
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

    }    
}
