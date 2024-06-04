using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.ReposInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class ReceptionistsRepo(ProfilesDbContext _context)
: IReceptionistsRepo
{
    public async Task<IReadOnlyCollection<Receptionist>> GetReceptionists(
        ReceptionistFilters filters, PageSettings pageSettings, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.GetByFiltration(nameof(Receptionist));
            
            if (!string.IsNullOrEmpty(filters.FullName)) 
                query.Append(ReposQueries.AddFullNameFilter(filters.FullName));

            query.Append(ReposQueries.AddOrder(filters.OrderBy, filters.OrderType));
            query.Append(ReposQueries.Pagination);
            
            var parameters = new DynamicParameters(filters);
            parameters.Add("Page", pageSettings.Page);
            parameters.Add("PageSize", pageSettings.PageSize);
            var receptionists = await connection.QueryAsync<Receptionist>(
                new CommandDefinition(query.ToString(), parameters, cancellationToken: cancellationToken));
            return receptionists.ToList().AsReadOnly();
        }
    }

    public async Task<Receptionist> GetReceptionistById(
        Guid idReceptionist, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.GetById(nameof(Receptionist));
            var receptionist = await connection.QueryFirstOrDefaultAsync<Receptionist>(
                new CommandDefinition(query, new { idReceptionist }, cancellationToken: cancellationToken));
            return receptionist;
        }
    }

    public async Task CreateReceptionist(
        Receptionist receptionist, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.Create(receptionist);
            await connection.ExecuteAsync(
                new CommandDefinition(query, receptionist, cancellationToken: cancellationToken));
        }
    }

    public async Task UpdateReceptionist(Receptionist receptionist, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.UpdateById(receptionist);
            await connection.ExecuteAsync(
                new CommandDefinition(query, receptionist, cancellationToken: cancellationToken));
        }
    }

    public async Task DeleteReceptionist(
        Guid idReceptionist, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.DeleteById(nameof(Receptionist));
            await connection.ExecuteAsync(
                new CommandDefinition(query, new { idReceptionist }, cancellationToken: cancellationToken));
        }
    }
}