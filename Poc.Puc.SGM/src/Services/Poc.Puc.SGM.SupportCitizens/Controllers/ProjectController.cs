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

        public ProjectController(IDbContext dbContext)
        {
            repository = new ProjectRepository(dbContext, "Project");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project project)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(0, 3000);
            project.Codigo = ticks.ToString();
            await repository.InsertAsync(project);

            return Ok(project.Codigo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, ChangeStatusRequest request)
        {
            var project = await repository.GetByIdAsync(x => x.Id == id);

            project.UpdateDate = DateTime.Now;
            project.ChangeStatus(request.EmployeeEmail, request.Status);

            await repository.UpdateAsync(project, x=> x.Id == id);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var projects = await repository.GetAllAsync();
            return Ok(projects);
        }

        [HttpGet("{codigo}")]
        public async Task<IActionResult> Get([FromRoute] string codigo)
        {
            var project = await repository.GetByIdAsync(x => x.Codigo == codigo);
            return Ok(project);
        }
    }

    public class ChangeStatusRequest
    {
        public string EmployeeEmail { get; set; }

        public string Status { get; set; }
    }
}
