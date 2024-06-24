using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntitiesConfiguration;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(appointment => appointment.IdAppointment);
        builder.Property(appointment => appointment.Date).IsRequired().HasColumnType("date");
        builder.Property(appointment => appointment.Time).IsRequired().HasColumnType("time");
        builder.Property(appointment => appointment.IsApproved).IsRequired();
        builder.Property(appointment => appointment.IdPatient).IsRequired();
        builder.Property(appointment => appointment.IdDoctor).IsRequired();
        builder.Property(appointment => appointment.IdService).IsRequired();
        
        builder.Property(appointment => appointment.DoctorFullName).HasMaxLength(100);
        builder.Property(appointment => appointment.SpecializationName).HasMaxLength(50);
        builder.Property(appointment => appointment.PatientFullName).HasMaxLength(100);
        builder.Property(appointment => appointment.PatientDateOfBirth).HasColumnType("date");
        builder.Property(appointment => appointment.PatientPhoneNumber).HasMaxLength(30);
        builder.Property(appointment => appointment.ServiceName).HasMaxLength(50);
        
        builder.HasOne(appointment => appointment.Result)
            .WithOne(result => result.Appointment)
            .HasForeignKey<Appointment>(appointment => appointment.IdAppointment);
    }
}