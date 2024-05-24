using Application.Common.Interfaces;
using Application.Common.Interfaces.RepositoryInterfaces;
using Domain.Entities;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

public class OfficesRepo(IMongoDbContext _context) : IOfficesRepo
{
    public async Task<List<Office>> GetAllOffices()
    {
        return await _context.Offices
            .FindAsync(_ => true)
            .Result
            .ToListAsync();
    }

    public async Task<Office> GetOfficeById(Guid idOffice)
    {
        return await _context.Offices
            .FindAsync(office => office.IdOffice == idOffice)
            .Result
            .FirstOrDefaultAsync();
    }

    public async Task<Guid> CreateOffice(Office office)
    {
        await _context.Offices.InsertOneAsync(office);
        return office.IdOffice;
    }

    public Task UpdateOffice(FilterDefinition<Office> filter, UpdateDefinition<Office> update)
    {
        return _context.Offices
            .UpdateOneAsync(filter, update);
    }   

    public async Task DeleteOffice(Guid idOffice)
    {
        await _context.Offices.DeleteOneAsync(office => office.IdOffice == idOffice);
    }
}