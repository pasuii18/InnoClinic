using System.Reflection;
using Domain.Entities;
using Infrastructure.Common.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Contexts;

public class AppointmentsDbContext(DbContextOptions<AppointmentsDbContext> options,
    IOptions<PostgresDbOptions> sqlOptions)
    : DbContext(options)
{
    public virtual DbSet<Appointment> Appointment { get; set; }
    public virtual DbSet<Result> Result { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(sqlOptions.Value.PostgresConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}