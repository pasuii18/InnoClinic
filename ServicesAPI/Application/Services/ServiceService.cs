using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.ServiceDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using Application.Interfaces.ServicesInterfaces;
using Domain.Entities;
using Mapster;

namespace Application.Services;

public class ServiceService(IServiceRepo _serviceRepo, IServiceCategoryRepo _serviceCategoryRepo)
    : IServiceService
{
    public async Task<ICustomResult> GetServices(PageSettings pageSettings, 
        ServicesFilter servicesFilter, CancellationToken cancellationToken)
    {
        var services = await _serviceRepo.GetServices(pageSettings, servicesFilter, cancellationToken);
                
        var groupedServices = services
            .GroupBy(service => service.Specialization.SpecializationName)
            .Select(group => new ServiceGroupBySpecializationReadDto(
                group.Key, 
                group.Adapt<IReadOnlyCollection<ServiceReadDto>>()))
            .ToList();
        
        return new CustomResult(true, HttpStatusCode.OK, groupedServices);
    }

    public async Task<ICustomResult> GetServiceById(Guid idService, 
        CancellationToken cancellationToken)
    {
        var service = await _serviceRepo.GetServiceById(idService, cancellationToken);
        if(service == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceNotFound);
        
        var serviceDto = service.Adapt<ServiceExtendedReadDto>();
        return new CustomResult(true, HttpStatusCode.OK, serviceDto);
    }

    public async Task<ICustomResult> CreateService(ServiceCreateDto serviceCreateDto, 
        CancellationToken cancellationToken)
    {
        var serviceCategory = await _serviceCategoryRepo.GetServiceCategoryById(serviceCreateDto.IdServiceCategory, cancellationToken);
        if(serviceCategory == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceCategoryNotFound);
        
        var newService = serviceCreateDto.Adapt<Service>();
        newService.IdService = Guid.NewGuid();
        
        await _serviceRepo.CreateService(newService, cancellationToken);
        await _serviceRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK, newService.IdService);
    }

    public async Task<ICustomResult> UpdateService(ServiceUpdateDto serviceUpdateDto, 
        CancellationToken cancellationToken)
    {
        var serviceCategory = await _serviceCategoryRepo.GetServiceCategoryById(serviceUpdateDto.IdServiceCategory, cancellationToken);
        if(serviceCategory == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceCategoryNotFound);
        
        var service = await _serviceRepo.GetServiceById(serviceUpdateDto.IdService, cancellationToken);
        if(service == null) return new CustomResult(false, HttpStatusCode.NotFound);
        
        serviceUpdateDto.Adapt(service);
        await _serviceRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }

    public async Task<ICustomResult> UpdateServiceStatus(Guid idService, 
        CancellationToken cancellationToken)
    {
        var service = await _serviceRepo.GetServiceById(idService, cancellationToken);
        if(service == null) return new CustomResult(false, HttpStatusCode.NotFound);
        
        service.IsActive = !service.IsActive;
        await _serviceRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
}