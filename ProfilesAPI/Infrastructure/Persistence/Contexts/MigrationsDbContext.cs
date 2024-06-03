using System.Reflection;
using Domain.Entities;
using Infrastructure.Persistence.Common.EntityConfigurations;
using Infrastructure.Persistence.Common.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Contexts;

public class MigrationsDbContext(DbContextOptions<MigrationsDbContext> options,
    IOptions<SqlServerDbOptions> sqlOptions)
    : DbContext(options)
{
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(sqlOptions.Value.SqlServerConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}