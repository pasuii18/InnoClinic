using Application.Interfaces.RepoInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class ResultRepo(AppointmentsDbContext _context) : IResultRepo
{
    public async Task<Result> GetResultById(Guid idAppointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.GetById(nameof(Result));
            var result = await connection.QueryFirstOrDefaultAsync<Result>(
                new CommandDefinition(
                    query, new { IdAppointment = idAppointment }, cancellationToken: cancellationToken));
            
            return result;
        }
    }

    public async Task CreateResult(Result result, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.Create(result);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, result, cancellationToken: cancellationToken));
        }
    }

    public async Task UpdateResult(Result result, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.UpdateById(result);
            await connection.ExecuteAsync(
                new CommandDefinition(
                    query, result, cancellationToken: cancellationToken));
        }
    }
}