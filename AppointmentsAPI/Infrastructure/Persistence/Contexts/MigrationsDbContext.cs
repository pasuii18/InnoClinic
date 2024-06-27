using System.Reflection;
using Domain.Entities;
using Infrastructure.Common.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Contexts;

public class MigrationsDbContext(DbContextOptions<MigrationsDbContext> options,
    IOptions<PostgresDbOptions> sqlOptions)
    : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(sqlOptions.Value.PostgresConnectionString,
            options => options.EnableRetryOnFailure(
                maxRetryCount: 3,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorCodesToAdd: new List<string> { "57P01" }));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}