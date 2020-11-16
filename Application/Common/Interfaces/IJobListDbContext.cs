using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace JobList.Application.Common.Interfaces
{
    public interface IJobListDbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<EducationPeriod> EducationPeriods { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Experience> Experiences { get; set; }
        DbSet<Faculty> Faculties { get; set; }
        DbSet<Invitation> Invitations { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Recruiter> Recruiters { get; set; }
        DbSet<Resume> Resumes { get; set; }
        DbSet<ResumeLanguage> ResumeLanguages { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<School> Schools { get; set; }
        DbSet<Vacancy> Vacancies { get; set; }
        DbSet<WorkArea> WorkAreas { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellatinoToken);
    }
}
