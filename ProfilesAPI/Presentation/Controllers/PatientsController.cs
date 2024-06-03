using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.PatientDtos;
using Application.Services.PatientsFolder.Commands.DeletePatient;
using Application.Services.PatientsFolder.Queries.ViewPatientProfile;
using Application.Services.PatientsFolder.Queries.ViewPatients;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Common;

namespace ProfilesAPI.Controllers;

[Route("api/v1/[controller]")]
public class PatientsController : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPatients(
        [FromQuery] PageSettings pageSettings, [FromQuery] PatientFilters patientFilters, CancellationToken cancellationToken)
    {
        var query = new ViewPatientsQuery { PageSettings = pageSettings, PatientFilters = patientFilters };
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }


    [HttpGet("{idPatient}")]
    public async Task<IActionResult> ViewPatientProfileQuery(
        Guid idPatient, CancellationToken cancellationToken)
    {
        var query = new ViewPatientProfileQuery { IdPatient = idPatient };
        var result = await Mediator.Send(query, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePatient(
        PatientCreateDto patientCreateDto, CancellationToken cancellationToken)
    {
        var command = patientCreateDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePatient(
        PatientUpdateDto patientUpdateDto, CancellationToken cancellationToken)
    {
        var command = patientUpdateDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeletePatient(
        Guid idPatient, CancellationToken cancellationToken)
    {
        var command = new DeletePatientCommand { IdPatient = idPatient };
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
}