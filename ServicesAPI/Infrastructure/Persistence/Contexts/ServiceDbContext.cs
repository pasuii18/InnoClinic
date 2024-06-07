using System.Reflection;
using Domain.Entities;
using Infrastructure.Common.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Contexts;

public class ServiceDbContext(DbContextOptions<ServiceDbContext> options,
    IOptions<SqlServerDbOptions> sqlOptions) : DbContext(options)
{
    public DbSet<Service> Service { get; set; }
    public DbSet<ServiceCategory> ServiceCategory { get; set; }
    public DbSet<Specialization> Specialization { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(sqlOptions.Value.SqlServerConnectionString);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}