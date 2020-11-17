using JobList.Application.Common.Models;
using MediatR;

namespace JobList.Application.Companies
{
    public class GetCompaniesListQuery : IRequest<CompaniesListVm>
    {
        public Paging Paging { get; set; }
    }
}
