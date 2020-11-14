using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasIndex(e => e.Email)
                .HasName("UQ_Companies_Email")
                .IsUnique();

            builder.HasIndex(e => e.Name)
                .HasName("UQ_Companies_Name")
                .IsUnique();

            builder.HasIndex(e => e.Phone)
                .HasName("UQ_Companies_Phone")
                .IsUnique();

            builder.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.BossName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.FullDescription)
                .IsRequired();

            builder.Property(e => e.LogoMimetype)
                .HasMaxLength(5);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Phone)
                .HasMaxLength(15);

            builder.Property(e => e.ShortDescription)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.Site)
                .HasMaxLength(100);
        }
    }
}
