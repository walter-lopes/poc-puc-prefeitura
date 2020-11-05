using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Poc.Puc.SGM.SupportCitizens.Domain;
using Poc.Puc.SGM.SupportCitizens.Repositories;

namespace Poc.Puc.SGM.SupportCitizens.Controllers
{
    [Route("project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ProjectRepository repository;

        public ProjectController()
        {
            var repository = new ProjectRepository();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project project)
        {
            await repository.InsertAsync(project);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Project project)
        {
            await repository.UpdateAsync(project, x=> x.Id == id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await repository.GetAllAsync():
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var project = await repository.GetByIdAsync(x => x.Id == id);
            return Ok(project);
        }
    }
}
