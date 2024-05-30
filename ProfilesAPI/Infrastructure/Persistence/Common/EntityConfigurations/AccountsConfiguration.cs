using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntityConfigurations;

public class AccountsConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(doctor => doctor.IdAccount);
        builder.HasIndex(doctor => doctor.Email).IsUnique();
        builder.Property(doctor => doctor.Password).IsRequired().HasMaxLength(20);
        builder.HasIndex(doctor => doctor.PhoneNumber).IsUnique();
        builder.Property(doctor => doctor.IsEmailVerified).IsRequired();
        builder.Property(doctor => doctor.CreatedBy).IsRequired().HasMaxLength(30);
        builder.Property(doctor => doctor.CreatedAt).IsRequired().HasColumnType("date");
        builder.Property(doctor => doctor.UpdatedBy).IsRequired().HasMaxLength(30);
        builder.Property(doctor => doctor.UpdatedAt).IsRequired().HasColumnType("date");
        builder.Property(doctor => doctor.IdPhoto).IsRequired(false).HasMaxLength(30);

        builder.HasOne(doctor => doctor.Patient)
            .WithOne(doctorAccount => doctorAccount.Account)
            .HasForeignKey<Patient>(doctorAccount => doctorAccount.IdAccount);
        
        builder.HasOne(doctor => doctor.Doctor)
            .WithOne(doctorAccount => doctorAccount.Account)
            .HasForeignKey<Doctor>(doctorAccount => doctorAccount.IdAccount);
        
        builder.HasOne(doctor => doctor.Receptionist)
            .WithOne(doctorAccount => doctorAccount.Account)
            .HasForeignKey<Receptionist>(doctorAccount => doctorAccount.IdAccount);
    }
}