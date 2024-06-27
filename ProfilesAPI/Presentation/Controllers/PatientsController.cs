using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.PatientDtos;
using Application.Services.PatientsFolder.Commands.DeletePatient;
using Application.Services.PatientsFolder.Queries.ViewPatientProfile;
using Application.Services.PatientsFolder.Queries.ViewPatients;
using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace ProfilesAPI.Controllers;

[Route("api/v1/[controller]")]
public class PatientsController : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPatients(
        [FromQuery][AutoValidateAlways] PageSettings pageSettings,
        [FromQuery][AutoValidateAlways] PatientFilters patientFilters, CancellationToken cancellationToken)
    {
        var query = new GetPatientsQuery { PageSettings = pageSettings, PatientFilters = patientFilters };
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }


    [HttpGet("{idPatient}")]
    public async Task<IActionResult> ViewPatientProfileQuery(
        Guid idPatient, CancellationToken cancellationToken)
    {
        var query = new GetPatientProfileQuery { IdPatient = idPatient };
        var result = await Mediator.Send(query, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePatient(
        [AutoValidateAlways] CreatePatientDto createPatientDto, CancellationToken cancellationToken)
    {
        var command = createPatientDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdatePatient(
        [AutoValidateAlways] UpdatePatientDto updatePatientDto, CancellationToken cancellationToken)
    {
        var command = updatePatientDto.MapInCommand();
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