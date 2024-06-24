using Application.Interfaces.RepoInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class ResultRepo(AppointmentsDbContext _context) : IResultRepo
{
    public async Task<Result> GetResultById(Guid idResult, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.GetById(nameof(Result));
            var result = await connection.QueryFirstOrDefaultAsync<Result>(
                new CommandDefinition(
                    query, new { IdResult = idResult }, cancellationToken: cancellationToken));
            
            return result;
        }
    }
    
    public async Task<Result> GetResultByAppointmentId(Guid idAppointment, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = QueryBuilder.GetBy(nameof(Result));
            query.Append(QueryBuilder.LeftJoin(nameof(Result), nameof(Appointment), $"Id{nameof(Appointment)}"));
            query.Append(QueryBuilder.Filtration);
            query.Append(QueryBuilder.AddJoinFilter(nameof(Result), $"Id{nameof(Appointment)}"));

            var result = await connection.QueryAsync<Result, Appointment, Result>(
                new CommandDefinition(
                    query.ToString(), new { IdAppointment = idAppointment }, cancellationToken: cancellationToken),
                (result, appointment) =>
                {
                    result.Appointment = appointment;
                    return result;
                },
                splitOn: $"Id{nameof(Appointment)}");

            return result.FirstOrDefault();
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