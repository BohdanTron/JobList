using JobList.Application.Common.Interfaces;
using JobList.Domain.Common;
using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JobList.Persistence
{
    public class JobListDbContext : DbContext, IJobListDbContext
    {
        public JobListDbContext(DbContextOptions<JobListDbContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<EducationPeriod> EducationPeriods { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<ResumeLanguage> ResumeLanguages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<WorkArea> WorkAreas { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //TODO: Replace with current user
                        entry.Entity.CreatedBy = "bohdan tron";
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        //TODO: Replace with current user
                        entry.Entity.ModifiedBy = "bohdan tron";
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobListDbContext).Assembly);
        }
    }
}
