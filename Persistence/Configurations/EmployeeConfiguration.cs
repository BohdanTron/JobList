using JobList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobList.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasIndex(e => e.Email)
                .IsUnique();

            builder.Property(e => e.BirthDate)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(e => e.CityId)
                .IsRequired();

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
                .HasMaxLength(15);

            builder.Property(e => e.PhotoMimeType)
                .HasMaxLength(5);

            builder.Property(e => e.Sex)
                .HasMaxLength(6);
        }
    }
}
