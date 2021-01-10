using Microsoft.AspNetCore.Mvc;
using Poc.Puc.SGM.SupportCitizens.Domain;
using Poc.Puc.SGM.SupportCitizens.Repositories;
using Poc.Puc.SGM.SupportCitizens.Services;
using System;
using System.Threading.Tasks;

namespace Poc.Puc.SGM.SupportCitizens.Controllers
{

    [Route("employee")]
    [ApiController]
    public class EmplooyesController : ControllerBase
    {
        private readonly EmplooyeRepository repository;

        public EmplooyesController(IDbContext dbContext)
        {
            repository = new EmplooyeRepository(dbContext, "Employee");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Funcionario emp)
        {
            await repository.InsertAsync(emp);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id,[FromBody] Funcionario emp)
        {
            await repository.UpdateAsync(emp, x => x.Id == id);

            return Ok();
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> Get([FromRoute] string email)
        {
            var emp = await repository.GetByIdAsync(x => x.Email == email);

            return Ok(emp);
        }
    }
}
