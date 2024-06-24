using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntitiesConfiguration;

public class ResultConfiguration : IEntityTypeConfiguration<Result>
{
    public void Configure(EntityTypeBuilder<Result> builder)
    {
        builder.HasKey(result => result.IdResult);
        builder.Property(result => result.Date).IsRequired().HasColumnType("date");
        builder.Property(result => result.Complaints).IsRequired().HasMaxLength(300);
        builder.Property(result => result.Conclusion).IsRequired().HasMaxLength(300);
        builder.Property(result => result.Recommendations).IsRequired().HasMaxLength(300);
        builder.Property(result => result.IdAppointment).IsRequired();

        builder.HasOne(result => result.Appointment)
            .WithOne(appointment => appointment.Result)
            .HasForeignKey<Result>(result => result.IdAppointment);
    }
}