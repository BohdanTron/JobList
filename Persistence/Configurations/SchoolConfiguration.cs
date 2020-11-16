using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.HasIndex(e => e.Name)
                .HasName("UQ_Schools_Name")
                .IsUnique();            

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
