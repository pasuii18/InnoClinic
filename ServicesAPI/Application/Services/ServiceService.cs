using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.ServiceDtos;
using Application.Common.Specifications;
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
        if(await IsServiceCategoryNotExist(servicesFilter.IdServiceCategory, cancellationToken)) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceCategoryNotFound);
        
        var services = await _serviceRepo.GetServices(
            new GetServicesSpecification(pageSettings, servicesFilter), cancellationToken);
                
        var groupedServices = services
            .GroupBy(service => service.Specialization!.SpecializationName)
            .Select(group => new ServiceGroupBySpecializationReadDto(
                group.Key, 
                group.Adapt<IReadOnlyCollection<ServiceReadDto>>()))
            .ToList();
        
        return new CustomResult(true, HttpStatusCode.OK, groupedServices);
    }

    public async Task<ICustomResult> GetServiceById(Guid idService, 
        CancellationToken cancellationToken)
    {
        var service = await _serviceRepo.GetServiceById(new GetServiceByIdSpecification(idService), cancellationToken);
        if(service == null) return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceNotFound);
        
        var serviceDto = service.Adapt<ServiceExtendedReadDto>();
        return new CustomResult(true, HttpStatusCode.OK, serviceDto);
    }

    public async Task<ICustomResult> CreateService(ServiceCreateDto serviceCreateDto, 
        CancellationToken cancellationToken)
    {
        if(await IsServiceCategoryNotExist(serviceCreateDto.IdServiceCategory, cancellationToken)) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceCategoryNotFound);
        
        var newService = serviceCreateDto.Adapt<Service>();
        newService.IdService = Guid.NewGuid();
        
        await _serviceRepo.CreateService(newService, cancellationToken);
        await _serviceRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK, newService.IdService);
    }

    public async Task<ICustomResult> UpdateService(ServiceUpdateDto serviceUpdateDto, 
        CancellationToken cancellationToken)
    {
        if(await IsServiceCategoryNotExist(serviceUpdateDto.IdServiceCategory, cancellationToken)) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ServiceCategoryNotFound);
        
        var service = await _serviceRepo.GetServiceById(
            new GetServiceByIdSpecification(serviceUpdateDto.IdService), cancellationToken);
        if(service == null) return new CustomResult(false, HttpStatusCode.NotFound);
        
        serviceUpdateDto.Adapt(service);
        await _serviceRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }

    public async Task<ICustomResult> UpdateServiceStatus(Guid idService, 
        CancellationToken cancellationToken)
    {
        var service = await _serviceRepo.GetServiceById(new GetServiceByIdSpecification(idService), cancellationToken);
        if(service == null) return new CustomResult(false, HttpStatusCode.NotFound);
        
        service.IsActive = !service.IsActive;
        await _serviceRepo.SaveChanges(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
    
    private async Task<bool> IsServiceCategoryNotExist(Guid idServiceCategory, CancellationToken cancellationToken)
    {
        var serviceCategory = await _serviceCategoryRepo.GetServiceCategoryById(
            new GetServiceCategoryByIdSpecification(idServiceCategory), cancellationToken);
        return serviceCategory == null;
    }
}