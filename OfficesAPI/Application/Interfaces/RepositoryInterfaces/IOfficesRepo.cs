using Application.Common;
using Domain.Entities;
using MongoDB.Driver;

namespace Application.Interfaces.RepositoryInterfaces;

public interface IOfficesRepo
{
    public Task<IReadOnlyCollection<Office>> GetAllOffices(PageSettings pageSettings, CancellationToken cancellationToken);
    public Task<Office> GetOfficeById(Guid idOffice, CancellationToken cancellationToken);
    public Task CreateOffice(Office office, CancellationToken cancellationToken);
    public Task UpdateOffice(FilterDefinition<Office> filter, UpdateDefinition<Office> update, CancellationToken cancellationToken);
    public Task DeleteOffice(Guid idOffice, CancellationToken cancellationToken);
}