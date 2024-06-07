using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfiguration;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.HasKey(service => service.IdSpecialization);
        builder.Property(service => service.SpecializationName).IsRequired().HasMaxLength(50);
        builder.Property(service => service.IsActive).IsRequired();
    }
}