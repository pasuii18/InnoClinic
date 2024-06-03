using Application.Common.Dtos;
using Application.Interfaces.ReposInterfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Persistence.Common;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories;

public class ReceptionistsRepo(ProfilesDbContext _context)
: IReceptionistsRepo
{
    private const string TableName = "Receptionist";
    
    public async Task<IReadOnlyCollection<Receptionist>> GetReceptionists(
        PageSettings pageSettings, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.GetAllFrom(TableName) + ReposQueries.Pagination;
            var receptionists = await connection.QueryAsync<Receptionist>(query, pageSettings);
            return receptionists.ToList().AsReadOnly();
        }
    }

    public async Task<Receptionist> GetReceptionistById(
        Guid idReceptionist, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.GetById(TableName);
            var receptionist = await connection.QueryFirstOrDefaultAsync(query, new { idReceptionist });
            return receptionist;
        }
    }

    public async Task CreateReceptionist(
        Receptionist receptionist, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = @"INSERT INTO Receptionists 
                (IdReceptionist, FirstName, LastName, MiddleName, 
                 IdAccount, IdOffice)
                        VALUES 
                (@IdReceptionist, @FirstName, @LastName, @MiddleName, 
                 @IdAccount, @IdOffice)";
    
            await connection.ExecuteAsync(query, receptionist);
        }
    }

    public async Task DeleteReceptionist(
        Guid idReceptionist, CancellationToken cancellationToken)
    {
        using (var connection = _context.CreateConnection())
        {
            var query = ReposQueries.DeleteById(TableName);
            await connection.ExecuteAsync(query, new { idReceptionist });
        }
    }
}