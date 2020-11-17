using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class RecruiterConfiguration : IEntityTypeConfiguration<Recruiter>
    {
        public void Configure(EntityTypeBuilder<Recruiter> builder)
        {
            builder.HasIndex(e => e.Email)
                .HasName("UQ_Recruiters_Email")
                .IsUnique();

            builder.HasIndex(e => e.Phone)
                .HasName("UQ_Recruiters_Phone")
                .IsUnique();

            builder.Property(e => e.PhotoMimetype)
                .HasMaxLength(5);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Phone)
                .HasMaxLength(35);
           
            builder.HasOne(d => d.Company)
                .WithMany(p => p.Recruiters)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Recruiters_Companies");
        }
    }
}
