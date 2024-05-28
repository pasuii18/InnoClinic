using System.Net;
using Application.Common;
using Application.Common.Dtos.OfficesDtos;
using Application.Interfaces;
using Application.Interfaces.ServicesInterfaces;
using Infrastructure.Common;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace Presentation.Controllers;

[Route("api/v1/[controller]")]
public class OfficesController(
    IOfficesService _officesService) 
    : ControllerBase
{
    [HttpGet]
    [Route("getAllOffices")]
    public async Task<ICustomResult> GetAllOffices([AutoValidateAlways] PageSettings pageSettings, 
        CancellationToken cancellationToken)
    {
        var offices = await _officesService.GetAllOffices(pageSettings, cancellationToken);
        return new CustomResult(true, "Success!", (int)HttpStatusCode.OK, offices);
    }
    
    [HttpGet]
    [Route("{idOffice}/information")]
    public async Task<ICustomResult> GetOfficeInfo(Guid idOffice, 
        CancellationToken cancellationToken)
    {
        var office = await _officesService.GetOfficeInfo(idOffice, cancellationToken);
        return new CustomResult(true, "Success!", (int)HttpStatusCode.OK, office);
    }
    
    [HttpPut]
    [Route("{idOffice}/status")]
    public async Task<ICustomResult> ChangeOfficeStatus(Guid idOffice, 
        CancellationToken cancellationToken)
    {
        var result = await _officesService.ChangeOfficeStatus(idOffice, cancellationToken);
        return new CustomResult(true, $"Office status updated to | {(result ? "Active" : "Not active")} | successfully!", 
            (int)HttpStatusCode.Created);
    }
    
    [HttpPost]
    public async Task<ICustomResult> CreateOffice([AutoValidateAlways] OfficeCreateDto officeCreateDto,
        CancellationToken cancellationToken)
    {
        var result = await _officesService.CreateOffice(officeCreateDto, cancellationToken);
        return new CustomResult(true, $"Office created successfully!", (int)HttpStatusCode.Created, result);
    }
    
    [HttpPut]
    public async Task<ICustomResult> UpdateOffice([AutoValidateAlways] OfficeUpdateDto officeUpdateDto,
        CancellationToken cancellationToken)
    {
        await _officesService.UpdateOffice(officeUpdateDto, cancellationToken);
        return new CustomResult(true, $"Office updated successfully!", (int)HttpStatusCode.NoContent);
    }
    
    [HttpDelete]
    [Route("{idOffice}")]
    public async Task<ICustomResult> DeleteOffice(Guid idOffice,
        CancellationToken cancellationToken)
    {
        await _officesService.DeleteOffice(idOffice, cancellationToken);
        return new CustomResult(true, $"Office deleted successfully!", (int)HttpStatusCode.NoContent);
    }
}