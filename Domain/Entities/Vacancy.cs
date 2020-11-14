using JobList.Domain.Common;
using System.Collections.Generic;

namespace JobList.Domain.Entities
{
    public class Vacancy : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Offering { get; set; }
        public string Requirements { get; set; }
        public string BePlus { get; set; }
        public bool? IsChecked { get; set; }
        public decimal? Salary { get; set; }
        public string FullPartTime { get; set; }
        public int RecruiterId { get; set; }
        public int CityId { get; set; }
        public int WorkAreaId { get; set; }

        public City City { get; set; }
        public Recruiter Recruiter { get; set; }
        public WorkArea WorkArea { get; set; }
        
        public ICollection<Invitation> Invitations { get; set; }
    }
}
