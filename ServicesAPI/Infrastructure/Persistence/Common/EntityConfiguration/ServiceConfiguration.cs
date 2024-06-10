using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfiguration;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(service => service.IdService);
        builder.Property(service => service.ServiceName).IsRequired().HasMaxLength(50);
        builder.Property(service => service.Price).IsRequired().HasColumnType("decimal").HasPrecision(10, 2);
        builder.Property(service => service.IsActive).IsRequired();
        builder.Property(service => service.IdServiceCategory).IsRequired();
        builder.Property(service => service.IdSpecialization).IsRequired(false);
        
        builder.HasOne(service => service.Specialization)
            .WithMany(specialization => specialization.Services)
            .HasForeignKey(service => service.IdSpecialization);
        
        builder.HasOne(service => service.ServiceCategory)
            .WithMany(serviceCategory => serviceCategory.Services)
            .HasForeignKey(service => service.IdServiceCategory);
    }
}