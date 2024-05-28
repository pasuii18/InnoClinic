using Application.Common;
using Application.Common.Dtos.OfficesDtos;
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
    public async Task<ActionResult<IReadOnlyCollection<OfficeReadDto>>> GetAllOffices([AutoValidateAlways] PageSettings pageSettings, 
        CancellationToken cancellationToken)
    {
        var offices = await _officesService.GetAllOffices(pageSettings, cancellationToken);
        return Ok(offices);
    }
    
    [HttpGet]
    [Route("{idOffice}/information")]
    public async Task<ActionResult<OfficeReadDto>> GetOfficeInfo(Guid idOffice, 
        CancellationToken cancellationToken)
    {
        var office = await _officesService.GetOfficeInfo(idOffice, cancellationToken);
        return Ok(office);
    }
    
    [HttpPut]
    [Route("{idOffice}/status")]
    public async Task<IActionResult> ChangeOfficeStatus(Guid idOffice, 
        CancellationToken cancellationToken)
    {
        var result = await _officesService.ChangeOfficeStatus(idOffice, cancellationToken);
        return Ok($"Office status updated to \"{(result ? "Active" : "Not active")}\"");
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateOffice([AutoValidateAlways] OfficeCreateDto officeCreateDto,
        CancellationToken cancellationToken)
    {
        var result = await _officesService.CreateOffice(officeCreateDto, cancellationToken);
        return Ok($"Office created successfully. Id is \"{result}\"");
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateOffice([AutoValidateAlways] OfficeUpdateDto officeUpdateDto,
        CancellationToken cancellationToken)
    {
        await _officesService.UpdateOffice(officeUpdateDto, cancellationToken);
        return Ok("Office updated");
    }
    
    [HttpDelete]
    [Route("{idOffice}")]
    public async Task<IActionResult> DeleteOffice(Guid idOffice,
        CancellationToken cancellationToken)
    {
        await _officesService.DeleteOffice(idOffice, cancellationToken);
        return NoContent();
    }
}