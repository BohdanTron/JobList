using AutoMapper;
using AutoMapper.QueryableExtensions;
using JobList.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace JobList.Application.Cities.Queries
{
    internal class GetCitiesListQueryHandler : IRequestHandler<GetCitiesListQuery, CitiesListVm>
    {
        private readonly IJobListDbContext _context;
        private readonly IMapper _mapper;

        public GetCitiesListQueryHandler(IJobListDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CitiesListVm> Handle(GetCitiesListQuery request, CancellationToken cancellationToken)
        {
            var cities = await _context.Cities
                .ProjectTo<CityDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var vm = new CitiesListVm
            {
                Cities = cities
            };

            return vm;
        }
    }
}
