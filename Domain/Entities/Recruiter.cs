using JobList.Domain.Common;
using System.Collections.Generic;

namespace JobList.Domain.Entities
{
    public class Recruiter : AuditableEntity
    {
        public Recruiter()
        {
            Vacancies = new HashSet<Vacancy>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public byte[] PhotoData { get; set; }
        public string PhotoMimetype { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }

        public Company Company { get; set; }
        public Role Role { get; set; }

        public ICollection<Vacancy> Vacancies { get; set; }
    }
}
