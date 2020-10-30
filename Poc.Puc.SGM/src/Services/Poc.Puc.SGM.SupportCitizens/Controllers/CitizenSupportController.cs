using Microsoft.AspNetCore.Mvc;
using Poc.Puc.SGM.SupportCitizens.Services;

namespace Poc.Puc.SGM.SupportCitizens.Controllers
{
    [Route("citizen/support")]
    [ApiController]
    public class CitizenSupportController : ControllerBase
    {   
        [Route("{identifier}")]
        public IActionResult GetByIdentifier([FromRoute] string identifier)
        {
            var service = new STURService();

            return Ok(service.GetByIdentifier(identifier));
        }
    }
}
