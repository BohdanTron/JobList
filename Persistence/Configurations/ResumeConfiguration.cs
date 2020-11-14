using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.Property(e => e.Introduction)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(e => e.Position)
                .HasMaxLength(100);

            builder.Property(e => e.Facebook)
                .HasMaxLength(200);

            builder.Property(e => e.FamilyState)
                .HasMaxLength(20);

            builder.Property(e => e.Github)
                .HasMaxLength(200);

            builder.Property(e => e.Instagram)
                .HasMaxLength(200);

            builder.Property(e => e.KeySkills)
                .IsRequired();

            builder.Property(e => e.Linkedin)
                .HasMaxLength(200);

            builder.Property(e => e.Skype)
                .HasMaxLength(200);

            builder.Property(e => e.SoftSkills)
                .IsRequired();

            builder.HasOne(d => d.Employee)
                .WithMany(p => p.Resumes)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Resumes_Employees");
        }
    }
}
