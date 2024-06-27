using Application.Common.Dtos;
using Application.Common.Dtos.DoctorDtos;
using Application.Common.Dtos.Filters;
using Application.Services.DoctorsFolder.Queries.ViewDoctorProfile;
using Application.Services.DoctorsFolder.Queries.ViewDoctors;
using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace ProfilesAPI.Controllers;

[Route("api/v1/[controller]")]
public class DoctorsController  : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetDoctors(
        [FromQuery][AutoValidateAlways] PageSettings pageSettings, 
        [FromQuery][AutoValidateAlways] DoctorFilters patientFilters, CancellationToken cancellationToken)
    {
        var query = new GetDoctorsQuery { PageSettings = pageSettings, DoctorFilters = patientFilters };
        var result = await Mediator.Send(query, cancellationToken);
        return Result(result);
    }


    [HttpGet("{idDoctor}")]
    public async Task<IActionResult> ViewDoctorProfileQuery(
        Guid idDoctor, CancellationToken cancellationToken)
    {
        var query = new GetDoctorProfileQuery { IdDoctor = idDoctor };
        var result = await Mediator.Send(query, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDoctor(
        [AutoValidateAlways] CreateDoctorDto createDoctorDto, CancellationToken cancellationToken)
    {
        var command = createDoctorDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateDoctor(
        [AutoValidateAlways] UpdateDoctorDto updateDoctorDto, CancellationToken cancellationToken)
    {
        var command = updateDoctorDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpPut("status")]
    public async Task<IActionResult> UpdateDoctorStatus(
        [AutoValidateAlways] UpdateDoctorStatusDto updateDoctorStatusDto, CancellationToken cancellationToken)
    {
        var command = updateDoctorStatusDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
}