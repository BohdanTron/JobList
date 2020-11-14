using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class ResumeLanguageConfiguration : IEntityTypeConfiguration<ResumeLanguage>
    {
        public void Configure(EntityTypeBuilder<ResumeLanguage> builder)
        {
            builder.HasOne(d => d.Resume)
                .WithMany(p => p.ResumeLanguages)
                .HasForeignKey(d => d.ResumeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ResumeLanguages_Resumes");
        }
    }
}
