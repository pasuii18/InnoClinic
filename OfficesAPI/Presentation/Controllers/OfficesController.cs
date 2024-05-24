using Domain.Common.Dtos.OfficesDtos;
using Domain.Common.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;

namespace Presentation.Controllers;

[Route("api/v1/[controller]")]
public class OfficesController(
    IOfficesService _officesService) 
    : Controller
{
    [HttpGet]
    [Route("getAllOffices")]
    public async Task<ActionResult<List<OfficeReadDto>>> GetAllOffices()
    {
        Log.Logger.Information("Received request to get all offices.");
        return Ok(await _officesService.GetAllOffices());
    }
    
    [HttpGet]
    [Route("{idOffice}/getInfo")]
    public async Task<ActionResult<OfficeReadDto>> GetOfficeInfo(
        Guid idOffice)
    {
        Log.Logger.Information($"Received request to get office information." +
                               $" IdOffice is {idOffice}");
        return Ok(await _officesService.GetOfficeInfo(idOffice));
    }
    
    [HttpPut]
    [Route("{idOffice}/changeStatus")]
    public async Task<ActionResult> ChangeOfficeStatus(
        Guid idOffice,
        OfficeStatusUpdateDto officeStatusUpdateDto)
    {
        Log.Logger.Information($"Received request to change office status." +
                               $" IdOffice is {idOffice}" +
                               $" Status is {officeStatusUpdateDto.IsActive}");
        
        await _officesService.ChangeOfficeStatus(idOffice, officeStatusUpdateDto);
        return Ok("Office status updated");
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<Guid>> CreateOffice(
        OfficeCreateDto officeCreateDto,
        [FromServices] IValidator<OfficeCreateDto> validator)
    {
        var validationResult = await validator.ValidateAsync(officeCreateDto);
        if (!validationResult.IsValid)
        {
            var errorMessage = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errorMessage);
        }

        Log.Logger.Information($"Received request to create office. " +
                               $"Create Office Object: {System.Text.Json.JsonSerializer.Serialize(officeCreateDto)}");
        
        return Ok(await _officesService.CreateOffice(officeCreateDto));
    }
    
    [HttpPut]
    [Route("{idOffice}/update")]
    public async Task<ActionResult> UpdateOffice(
        Guid idOffice, 
        OfficeUpdateDto officeUpdateDto,
        [FromServices] IValidator<OfficeUpdateDto> validator)
    {
        var validationResult = await validator.ValidateAsync(officeUpdateDto);
        if (!validationResult.IsValid)
        {
            var errorMessage = string.Join(" ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new ValidationException(errorMessage);
        }
        
        Log.Logger.Information($"Received request to update office. " +
                               $"Update Office Object: {System.Text.Json.JsonSerializer.Serialize(officeUpdateDto)}");
        await _officesService.UpdateOffice(idOffice, officeUpdateDto);
        return Ok("Office updated");
    }
    
    [HttpDelete]
    [Route("{idOffice}/delete")]
    public async Task<ActionResult> DeleteOffice(
        Guid idOffice)
    {
        Log.Logger.Information($"Received request to delete office." +
                               $" IdOffice is {idOffice}");
        await _officesService.DeleteOffice(idOffice);
        return NoContent();
    }
}