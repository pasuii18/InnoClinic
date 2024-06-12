using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IServiceRepo
{
    public Task<IReadOnlyCollection<Service>> GetServices(
        Specification<Service> specification, CancellationToken cancellationToken);
    public Task<Service> GetServiceById(
        Specification<Service> specification, CancellationToken cancellationToken);
    public Task CreateService(Service service, CancellationToken cancellationToken);
    public Task SaveChanges(CancellationToken cancellationToken);
}