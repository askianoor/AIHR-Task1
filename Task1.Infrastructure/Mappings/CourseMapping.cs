using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task1.Domain.Models;

namespace Task1.Infrastructure.Mappings;

public class CourseMapping : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(b => b.Level).IsRequired();

        builder.Property(b => b.Type).IsRequired();

        builder.Property(b => b.Duration).IsRequired();

        builder.Property(b => b.IsActive).IsRequired();

        builder.Property(b => b.CategoryId).IsRequired();

        builder.Property(b => b.TutorId).IsRequired();

    }
}