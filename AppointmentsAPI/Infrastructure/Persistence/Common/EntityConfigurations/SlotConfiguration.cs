using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Common.EntitiesConfiguration;

public class SlotConfiguration : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder.HasKey(slot => slot.IdSlot);
        builder.Property(slot => slot.Date).IsRequired().HasColumnType("date");
        builder.Property(slot => slot.StartTime).IsRequired().HasColumnType("time");
        builder.Property(slot => slot.EndTime).IsRequired().HasColumnType("time");
        builder.Property(slot => slot.IsFree).IsRequired();
    }
}