using Domain.Entities;
using MongoDB.Driver;

namespace Application.Common.Interfaces.RepositoryInterfaces;

public interface IOfficesRepo
{
    public Task<List<Office>> GetAllOffices();
    public Task<Office> GetOfficeById(Guid idOffice);
    public Task<Guid> CreateOffice(Office office);
    public Task UpdateOffice(FilterDefinition<Office> filter, UpdateDefinition<Office> update);
    public Task DeleteOffice(Guid idOffice);
}