using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IServiceRepo
{
    public Task<IReadOnlyCollection<Service>> GetServices(CancellationToken cancellationToken);
    public Task<Service> GetServiceById(Guid idService, CancellationToken cancellationToken);
    public Task CreateService(Service service, CancellationToken cancellationToken);
}