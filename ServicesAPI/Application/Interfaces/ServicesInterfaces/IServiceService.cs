using Application.Common.Dtos.ServiceDtos;
using Domain.Entities;

namespace Application.Interfaces.ServicesInterfaces;

public interface IServiceService
{
    Task<ICustomResult> GetServices(CancellationToken cancellationToken);
    Task<ICustomResult> GetServiceById(Guid idService, CancellationToken cancellationToken);
    Task<ICustomResult> CreateService(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken);
    Task<ICustomResult> UpdateService(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken);
    Task<ICustomResult> UpdateServiceStatus(Guid idService, CancellationToken cancellationToken);
}