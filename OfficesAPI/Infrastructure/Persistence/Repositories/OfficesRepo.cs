using Application.Common;
using Application.Common.Dtos;
using Application.Interfaces;
using Application.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using Infrastructure.Common;
using MongoDB.Driver;

namespace Infrastructure.Persistence.Repositories;

public class OfficesRepo(IMongoDbContext _context) : IOfficesRepo
{
    public async Task<IReadOnlyCollection<Office>> GetAllOffices(PageSettings pageSettings,CancellationToken cancellationToken)
    {
        return await _context.Offices
            .Find(_ => true)
            .Skip((pageSettings.Page - 1) * pageSettings.PageSize)
            .Limit(pageSettings.PageSize)
            .ToListAsync(cancellationToken);
    }

    public async Task<Office> GetOfficeById(Guid idOffice, CancellationToken cancellationToken)
    {
        return await _context.Offices
            .Find(office => office.IdOffice == idOffice)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task CreateOffice(Office office, CancellationToken cancellationToken)
    {
        await _context.Offices.InsertOneAsync(office, cancellationToken);
    }

    public Task UpdateOffice(FilterDefinition<Office> filter, 
        UpdateDefinition<Office> update, 
        CancellationToken cancellationToken)
    {
        return _context.Offices
            .UpdateOneAsync(filter, update, null, cancellationToken);
    }   

    public async Task DeleteOffice(Guid idOffice, CancellationToken cancellationToken)
    {
        await _context.Offices.DeleteOneAsync(office => office.IdOffice == idOffice, cancellationToken);
    }
}