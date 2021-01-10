using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAppAuthenticationSGM.Models;
using WebAppAuthenticationSGM.Repositories;
using WebAppAuthenticationSGM.Services;

namespace WebAppAuthenticationSGM.Controllers
{
    [Route("v1/account")]
    [ApiController]
    public class AuthenticationController:ControllerBase
    {

        private readonly UserRepository _userRepository;

        public AuthenticationController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticate([FromBody] User model)
        {

            User user = _userRepository.Get(model.Login, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            user.Token = token;

            return user;
        }

        [HttpPost]
        public string Create(User model)
        {
            User user = _userRepository.Get(model.Login, model.Password);
            
            if (user == null)
            {
                _userRepository.Create(model);
                return String.Format("Usuário - {0} cadastrado com sucesso.", model.Login);
            }
            else
            {
                return "Usuário informado já existe.";
            }                
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User model)
        {
            User user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userRepository.Update(id, model);
                return NoContent();
            }           
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            User user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                _userRepository.Remove(user.Id);
                return NoContent();
            }            
        }
        
        //[HttpGet]
        //[Route("anonymous")]
        //[AllowAnonymous]
        //public string Anonymous() => "Anônimo";

        //[HttpGet]
        //[Route("authenticated")]
        //[Authorize]
        //public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        //[HttpGet]
        //[Route("funcionario")]
        //[Authorize(Roles = "prefeito,vereador")]
        //public string Funcionario() => "Funcionario";
    }
}
