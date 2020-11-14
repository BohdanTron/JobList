using JobList.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobList.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<JobListDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(Constants.ConnectionStringName)));

            services.AddScoped<IJobListDbContext>(provider => provider.GetService<JobListDbContext>());

            return services;
        }
    }
}
