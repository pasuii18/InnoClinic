using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfiguration;

public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
{
    public void Configure(EntityTypeBuilder<ServiceCategory> builder)
    {
        builder.HasKey(service => service.IdServiceCategory);
        builder.Property(service => service.ServiceCategoryName).IsRequired().HasMaxLength(50);
        builder.Property(service => service.TimeSlotSize).IsRequired();
    }
}