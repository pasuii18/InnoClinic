using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.ServiceDtos;
using Domain.Entities;

namespace Application.Interfaces.ServicesInterfaces;

public interface IServiceService
{
    Task<ICustomResult> GetServices(PageSettings pageSettings, 
        ServicesFilter servicesFilter, CancellationToken cancellationToken);
    Task<ICustomResult> GetServiceById(Guid idService, CancellationToken cancellationToken);
    Task<ICustomResult> CreateService(ServiceCreateDto serviceCreateDto, CancellationToken cancellationToken);
    Task<ICustomResult> UpdateService(ServiceUpdateDto serviceUpdateDto, CancellationToken cancellationToken);
    Task<ICustomResult> UpdateServiceStatus(Guid idService, CancellationToken cancellationToken);
}