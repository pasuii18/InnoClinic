using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace ServicesAPI.Controllers;

[Route("api/v1/[controller]")]
public class AppointmentController(IAppointmentReadService _appointmentReadService,
    IAppointmentWriteService _appointmentWriteService) : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAppointments([FromQuery][AutoValidateAlways]PageSettings pageSettings, 
        [FromQuery][AutoValidateAlways]AppointmentsFilter filter, CancellationToken cancellationToken)
    {
        var result = await _appointmentReadService.GetAppointments(pageSettings, filter, cancellationToken);
        return Result(result);
    }
    
    [HttpGet("history")]
    public async Task<IActionResult> GetAppointmentsHistory([FromQuery][AutoValidateAlways]PageSettings pageSettings, 
        CancellationToken cancellationToken)
    {
        var result = await _appointmentReadService.GetAppointmentsHistory(pageSettings, cancellationToken);
        return Result(result);
    }
    
    [HttpGet("schedule/{idDoctor}")]
    public async Task<IActionResult> GetAppointmentsSchedule(Guid idDoctor, 
        [FromQuery][AutoValidateAlways]PageSettings pageSettings,
        [FromQuery][AutoValidateAlways]AppointmentsScheduleFilter filter, CancellationToken cancellationToken)
    {
        var result = await _appointmentReadService.GetAppointmentsSchedule(idDoctor, pageSettings, filter, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateAppointment(
        [FromBody][AutoValidateAlways]CreateAppointmentDto createAppointmentDto, CancellationToken cancellationToken)
    {
        var result = await _appointmentWriteService.CreateAppointment(createAppointmentDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut("{idAppointment}")]
    public async Task<IActionResult> UpdateAppointment(Guid idAppointment, 
        [FromBody][AutoValidateAlways]UpdateAppointmentDto updateAppointmentDto, CancellationToken cancellationToken)
    {
        var result = await _appointmentWriteService.UpdateAppointment(idAppointment, updateAppointmentDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut("{idAppointment}/status")]
    public async Task<IActionResult> UpdateAppointmentStatus(Guid idAppointment, CancellationToken cancellationToken)
    {
        var result = await _appointmentWriteService.UpdateAppointmentStatus(idAppointment, cancellationToken);
        return Result(result);
    }
    
    [HttpDelete("{idAppointment}")]
    public async Task<IActionResult> DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken)
    {
        var result = await _appointmentWriteService.DeleteAppointment(idAppointment, cancellationToken);
        return Result(result);
    }
}