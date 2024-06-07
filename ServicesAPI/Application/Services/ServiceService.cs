using Application.Common.Dtos.ServiceDtos;
using Application.Interfaces;
using Application.Interfaces.ServicesInterfaces;

namespace Application.Services;

public class ServiceService
    : IServiceService
{
    public async Task<ICustomResult> GetServices(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> GetServiceById(Guid idService, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> CreateService(ServiceCreateDto serviceCreateDto, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> UpdateService(ServiceUpdateDto serviceUpdateDto, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ICustomResult> UpdateServiceStatus(Guid idService, 
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}