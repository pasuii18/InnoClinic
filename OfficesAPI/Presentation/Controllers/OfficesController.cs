using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.OfficesDtos;
using Application.Interfaces;
using Application.Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Presentation.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace Presentation.Controllers;

[Route("api/v1/[controller]")]
public class OfficesController(IOfficesService _officesService) 
    : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOffices(
        [AutoValidateAlways] PageSettings pageSettings, 
        CancellationToken cancellationToken)
    {
        var result = await _officesService.GetAllOffices(pageSettings, cancellationToken);
        return Result(result);
    }
    
    [HttpGet]
    [Route("{idOffice}")]
    public async Task<IActionResult> GetOfficeInfo(
        string idOffice, 
        CancellationToken cancellationToken)
    {
        var result = await _officesService.GetOfficeInfo(idOffice, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateOffice(
        [AutoValidateAlways] OfficeCreateDto officeCreateDto,
        CancellationToken cancellationToken)
    {
        var result = await _officesService.CreateOffice(officeCreateDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOffice(
        [AutoValidateAlways] OfficeUpdateDto officeUpdateDto,
        CancellationToken cancellationToken)
    {
        var result = await _officesService.UpdateOffice(officeUpdateDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    [Route("{idOffice}")]
    public async Task<IActionResult> ChangeOfficeStatus(
        string idOffice, 
        CancellationToken cancellationToken)
    {
        var result = await _officesService.ChangeOfficeStatus(idOffice, cancellationToken);
        return Result(result);
    }
    
    [HttpDelete]
    [Route("{idOffice}")]
    public async Task<IActionResult> DeleteOffice(
        string idOffice,
        CancellationToken cancellationToken)
    {
        var result = await _officesService.DeleteOffice(idOffice, cancellationToken);
        return Result(result);
    }
}