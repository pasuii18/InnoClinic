using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.ServiceDtos;
using Application.Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace ServicesAPI.Controllers;

[Route("api/v1/[controller]")]
public class ServicesController(IServiceService _serviceService) 
    : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetServices(
        [FromQuery][AutoValidateAlways] PageSettings pageSettings, 
        [FromQuery][AutoValidateAlways] ServicesFilter servicesFilter, CancellationToken cancellationToken)
    {
        var result = await _serviceService.GetServices(pageSettings, servicesFilter, cancellationToken);
        return Result(result);
    }
    
    [HttpGet("{idService}")]
    public async Task<IActionResult> GetServiceById(Guid idService, CancellationToken cancellationToken)
    { 
        var result = await _serviceService.GetServiceById(idService, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateService([AutoValidateAlways] ServiceCreateDto serviceCreateDto,
        CancellationToken cancellationToken)
    {
        var result = await _serviceService.CreateService(serviceCreateDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateService([AutoValidateAlways] ServiceUpdateDto serviceUpdateDto,
        CancellationToken cancellationToken)
    {
        var result = await _serviceService.UpdateService(serviceUpdateDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut("{idService}")]
    public async Task<IActionResult> UpdateServiceStatus(Guid idService, CancellationToken cancellationToken)
    {
        var result = await _serviceService.UpdateServiceStatus(idService, cancellationToken);
        return Result(result);
    }
    
    [HttpDelete("{idService}")]
    public async Task<IActionResult> DeleteService(Guid idService, CancellationToken cancellationToken)
    {
        var result = await _serviceService.DeleteService(idService, cancellationToken);
        return Result(result);
    }
}