using JobList.Application.Common.Models;
using JobList.Application.Companies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    public class CompaniesController : JobListControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<CompaniesListVm>> Get([FromQuery] Paging paging)
        {
            return Ok(await Mediator.Send(new GetCompaniesListQuery { Paging = paging }));
        }
    }
}
