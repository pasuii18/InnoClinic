using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfiguration;

public class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
{
    public void Configure(EntityTypeBuilder<ServiceCategory> builder)
    {
        builder.HasKey(serviceCategory => serviceCategory.IdServiceCategory);
        builder.Property(serviceCategory => serviceCategory.ServiceCategoryName).IsRequired().HasMaxLength(50);
        builder.Property(serviceCategory => serviceCategory.TimeSlotSize).IsRequired();

        builder.HasMany(serviceCategory => serviceCategory.Services)
            .WithOne(service => service.ServiceCategory)
            .HasForeignKey(service => service.IdServiceCategory);

        
        // prob delete
        builder.HasData(new List<ServiceCategory>
        {
            new ServiceCategory
            {
                IdServiceCategory = Guid.NewGuid(),
                ServiceCategoryName = "Consultation",
                TimeSlotSize = 10
            },
            new ServiceCategory
            {
                IdServiceCategory = Guid.NewGuid(),
                ServiceCategoryName = "Diagnostics",
                TimeSlotSize = 20
            },
            new ServiceCategory
            {
                IdServiceCategory = Guid.NewGuid(),
                ServiceCategoryName = "Analyses",
                TimeSlotSize = 30
            }
        });
    }
}