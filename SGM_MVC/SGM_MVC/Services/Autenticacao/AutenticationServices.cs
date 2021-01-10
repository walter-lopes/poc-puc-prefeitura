using Newtonsoft.Json;
using SGM_MVC.Models.Authentication;
using SGM_MVC.Models.Servidor;
using SGM_MVC.Services.ServicesUtils;
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
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(Settings.HostApiGateWay + $"account/login")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Autenticacao parametro = new Autenticacao
            {
                Login = login,
                Password = senha
            };

            return await client.PostAsync("login", Utils.getJsonStringContent(parametro));                    
        }

        public HttpResponseMessage GenerateUserPass(Funcionario func)
        {            
            string login = func.Email.ToLower();
            string pass = "pass" + func.DataNascimento.ToString("yyyyMMdd");

            User user = new User()
            {
                Login = login,
                Password = pass,
                Role = func.Cargo,
                Name = func.Nome
            };            

            var client = new HttpClient();
            return client.PostAsync(Settings.HostApiGateWay+$"account", Utils.getJsonStringContent(user)).Result;
        }
    }
}
