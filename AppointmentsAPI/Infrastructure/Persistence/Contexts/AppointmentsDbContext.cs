using System.Data;
using Infrastructure.Common.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Contexts;

public class AppointmentsDbContext
    (IOptions<PostgresDbOptions> sqlOptions)
{
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(sqlOptions.Value.PostgresConnectionString);
    }
}