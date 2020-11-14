using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class EducatioPeriodConfiguration : IEntityTypeConfiguration<EducationPeriod>
    {
        public void Configure(EntityTypeBuilder<EducationPeriod> builder)
        {
            builder.Property(e => e.FinishDate)
                .HasColumnType("datetime");

            builder.Property(e => e.StartDate)
                .HasColumnType("datetime");

            builder.HasOne(d => d.Resume)
                .WithMany(p => p.EducationPeriods)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EucationPeriods_Resumes");
        }
    }
}
