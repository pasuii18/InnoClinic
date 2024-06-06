﻿using Application.Common.Dtos;
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
        var query = new ViewDoctorsQuery { PageSettings = pageSettings, DoctorFilters = patientFilters };
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }


    [HttpGet("{idDoctor}")]
    public async Task<IActionResult> ViewDoctorProfileQuery(
        Guid idDoctor, CancellationToken cancellationToken)
    {
        var query = new ViewDoctorProfileQuery { IdDoctor = idDoctor };
        var result = await Mediator.Send(query, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateDoctor(
        [AutoValidateAlways] DoctorCreateDto doctorCreateDto, CancellationToken cancellationToken)
    {
        var command = doctorCreateDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateDoctor(
        [AutoValidateAlways] DoctorUpdateDto doctorUpdateDto, CancellationToken cancellationToken)
    {
        var command = doctorUpdateDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpPut("status")]
    public async Task<IActionResult> UpdateDoctorStatus(
        [AutoValidateAlways] DoctorStatusUpdateDto doctorStatusUpdateDto, CancellationToken cancellationToken)
    {
        var command = doctorStatusUpdateDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
}