using System.Data;
using Infrastructure.Common.Options;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Persistence.Contexts;

public class AppointmentsDbContext
    (IOptions<PostgresDbOptions> sqlOptions)
{
    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(sqlOptions.Value.PostgresConnectionString);
    }
}