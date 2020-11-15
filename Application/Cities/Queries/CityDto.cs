using AutoMapper;
using JobList.Application.Common.Mappings;
using JobList.Domain.Entities;

namespace JobList.Application.Cities.Queries
{
    public class CityDto : IMapFrom<City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
