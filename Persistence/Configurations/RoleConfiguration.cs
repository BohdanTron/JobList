using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedNever();

            builder.HasIndex(e => e.Name)
                    .IsUnique();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
