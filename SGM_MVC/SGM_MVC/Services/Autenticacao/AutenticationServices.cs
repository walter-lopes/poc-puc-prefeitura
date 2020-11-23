using Newtonsoft.Json;
using SGM_MVC.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SGM_MVC.Services
{
    public class AutenticationServices
    {
        public async Task<HttpResponseMessage> Autenticar(String login, String senha)
        {
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44359/v1/account/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            Autenticacao parametro = new Autenticacao();
            parametro.Login = login;
            parametro.Password = senha;

            var jsonContent = JsonConvert.SerializeObject(parametro);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new
            MediaTypeHeaderValue("application/json");

            return await client.PostAsync("login", contentString);                    
        }
    }
}
