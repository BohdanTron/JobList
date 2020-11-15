using MediatR;

namespace JobList.Application.Cities.Queries
{
    public class GetCitiesListQuery : IRequest<CitiesListVm>
    {
    }
}
