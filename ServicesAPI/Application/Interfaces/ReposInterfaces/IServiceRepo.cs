using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IServiceRepo
{
    public Task<IReadOnlyCollection<Service>> GetServices(PageSettings pageSettings, ServicesFilter servicesFilter,
        CancellationToken cancellationToken);
    public Task<Service> GetServiceById(Guid idService, CancellationToken cancellationToken);
    public Task CreateService(Service service, CancellationToken cancellationToken);
    public Task SaveChanges(CancellationToken cancellationToken);
}