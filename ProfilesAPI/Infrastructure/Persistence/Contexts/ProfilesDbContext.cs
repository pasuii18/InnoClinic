using System.Data;
using Infrastructure.Persistence.Common.Options;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Infrastructure.Persistence.Contexts;

public class ProfilesDbContext
    (IOptions<SqlServerDbOptions> _options)
{
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_options.Value.SqlServerConnectionString);
    }
}