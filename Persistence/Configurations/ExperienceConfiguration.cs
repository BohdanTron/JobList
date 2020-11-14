using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.FinishDate)
                .HasColumnType("datetime");

            builder.Property(e => e.Position)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.StartDate)
                .HasColumnType("datetime");

            builder.HasOne(d => d.Resume)
                .WithMany(p => p.Experiences)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Experiences_Resumes");
        }
    }
}
