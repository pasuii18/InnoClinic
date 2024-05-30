using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfigurations;

public class PatientsConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(patient => patient.IdPatient);
        builder.Property(patient => patient.FirstName).IsRequired().HasMaxLength(30);
        builder.Property(patient => patient.LastName).IsRequired().HasMaxLength(30);
        builder.Property(patient => patient.MiddleName).IsRequired().HasMaxLength(30);
        builder.Property(patient => patient.IsLinkedToAccount).IsRequired();
        builder.Property(patient => patient.DateOfBirth).HasColumnType("date");
        builder.Property(patient => patient.IdAccount).IsRequired(false);

        builder.HasOne(patient => patient.Account)
            .WithOne(patientAccount => patientAccount.Patient)
            .HasForeignKey<Account>(patientAccount => patientAccount.IdAccount);
    }
}