using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfigurations;

public class DoctorsConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(doctor => doctor.IdDoctor);
        builder.Property(doctor => doctor.FirstName).IsRequired().HasMaxLength(30);
        builder.Property(doctor => doctor.LastName).IsRequired().HasMaxLength(30);
        builder.Property(doctor => doctor.MiddleName).IsRequired().HasMaxLength(30);
        builder.Property(doctor => doctor.DateOfBirth).IsRequired().HasColumnType("date");
        builder.Property(doctor => doctor.CareerStartYear).IsRequired().HasMaxLength(5);
        builder.Property(doctor => doctor.Status).IsRequired().HasMaxLength(5);
        builder.Property(doctor => doctor.IdAccount).IsRequired();
        builder.Property(doctor => doctor.IdSpecialization).IsRequired();
        builder.Property(doctor => doctor.IdOffice).IsRequired();

        builder.HasOne(doctor => doctor.Account)
            .WithOne(doctorAccount => doctorAccount.Doctor)
            .HasForeignKey<Account>(doctorAccount => doctorAccount.IdAccount);
    }
}