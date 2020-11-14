using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class InvintationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.HasOne(d => d.Employee)
                .WithMany(p => p.Invitations)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Invitations_Employees");

            builder.HasOne(d => d.Vacancy)
                .WithMany(p => p.Invitations)
                .HasForeignKey(d => d.VacancyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Invitations_Vacancies");
        }
    }
}
