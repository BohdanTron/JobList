using JobList.Application.Common.Mappings;
using JobList.Domain.Entities;

namespace JobList.Application.Companies
{
    public class CompanyDto : IMapFrom<Company>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
