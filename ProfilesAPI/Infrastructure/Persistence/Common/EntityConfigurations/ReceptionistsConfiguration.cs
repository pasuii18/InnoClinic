using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfigurations;

public class ReceptionistsConfiguration : IEntityTypeConfiguration<Receptionist>
{
    public void Configure(EntityTypeBuilder<Receptionist> builder)
    {
        builder.HasKey(receptionist => receptionist.IdReceptionist);
        builder.Property(receptionist => receptionist.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(receptionist => receptionist.LastName).IsRequired().HasMaxLength(20);
        builder.Property(receptionist => receptionist.MiddleName).IsRequired().HasMaxLength(20);
        builder.Property(receptionist => receptionist.IdAccount).IsRequired().HasMaxLength(30);
        builder.Property(receptionist => receptionist.IdOffice).IsRequired().HasMaxLength(30);
    }
}