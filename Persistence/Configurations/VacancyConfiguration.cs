using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.Property(e => e.Description)
                .IsRequired();

            builder.Property(e => e.FullPartTime)
                .HasMaxLength(25);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Offering)
                .IsRequired();

            builder.Property(e => e.Requirements)
                .IsRequired();

            builder.Property(e => e.Salary)
                .HasColumnType("money");

            builder.HasOne(d => d.Recruiter)
                .WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.RecruiterId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Vacancies_Recruiters");
        }
    }
}
