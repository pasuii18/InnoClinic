using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfiguration;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(specialization => specialization.IdSpecialization);
        builder.Property(specialization => specialization.SpecializationName).IsRequired().HasMaxLength(50);
        builder.Property(specialization => specialization.IsActive).IsRequired();
        
        builder.HasMany(specialization => specialization.Services)
            .WithOne(service => service.Specialization)
            .HasForeignKey(service => service.IdSpecialization);
    }
}