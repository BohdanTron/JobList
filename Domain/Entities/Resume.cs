using JobList.Domain.Common;
using System.Collections.Generic;

namespace JobList.Domain.Entities
{
    public class Resume : AuditableEntity
    {
        public Resume()
        {
            EducationPeriods = new HashSet<EducationPeriod>();
            Experiences = new HashSet<Experience>();
            ResumeLanguages = new HashSet<ResumeLanguage>();
        }

        public int Id { get; set; }
        public string Linkedin { get; set; }
        public string Github { get; set; }
        public string Facebook { get; set; }
        public string Skype { get; set; }
        public string Instagram { get; set; }
        public string Introduction { get; set; }
        public string Position { get; set; }
        public string FamilyState { get; set; }
        public string SoftSkills { get; set; }
        public string KeySkills { get; set; }
        public string Courses { get; set; }
        public int WorkAreaId { get; set; }
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public ICollection<EducationPeriod> EducationPeriods { get; }
        public ICollection<Experience> Experiences { get; }
        public ICollection<ResumeLanguage> ResumeLanguages { get; }
    }
}
