using Infrastructure.Persistence.Common.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Infrastructure.Persistence.Contexts;

public class ProfilesDbContext
    (IOptions<SqlServerDbOptions> _options)
{
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_options.Value.SqlServerConnectionString);
    }
}