using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobList.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JobList.Application.Companies
{
    internal class GetCompaniesQueryHandler : IRequestHandler<GetCompaniesListQuery, CompaniesListVm>
    {
        private readonly IJobListDbContext _context;
        private readonly IMapper _mapper;

        public GetCompaniesQueryHandler(IJobListDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CompaniesListVm> Handle(GetCompaniesListQuery request, CancellationToken cancellationToken)
        {
            var companies = await _context.Companies
                .Skip(request.Paging.Skip)
                .Take(request.Paging.Take)                
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CompaniesListVm
            {
                Companies = companies
            };

            return vm;
        }
    }
}
