using JobList.Application.Cities.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class CitiesController : JobListControllerBase
    {
        [HttpGet("all")]
        public async Task<ActionResult<CitiesListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetCitiesListQuery()));
        }
    }
}
