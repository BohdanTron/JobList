using Microsoft.EntityFrameworkCore;

namespace JobList.Persistence
{
    public class JobListDbContextFactory : DesignTimeDbContextFactoryBase<JobListDbContext>
    {
        protected override JobListDbContext CreateNewInstance(DbContextOptions<JobListDbContext> options)
        {
            return new JobListDbContext(options);
        }
    }
}
