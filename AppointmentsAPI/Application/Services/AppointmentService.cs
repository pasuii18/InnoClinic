using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Entities;
using Domain.Events.ServiceEvents;
using Mapster;

namespace Application.Services;

public class AppointmentService(IAppointmentRepo _appointmentRepo) : IAppointmentService
{
    public async Task<ICustomResult> GetAppointments(PageSettings pageSettings,
        AppointmentsFilter filter, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepo.GetAppointments(pageSettings, filter, cancellationToken);
        var appointmentsDto = appointments.Adapt<IReadOnlyCollection<AppointmentListReadDto>>();
        return new CustomResult(true, HttpStatusCode.OK, appointmentsDto);
    }

    public async Task<ICustomResult> GetAppointmentsHistory(PageSettings pageSettings,
        CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepo.GetAppointmentsHistory(pageSettings, cancellationToken);
        var appointmentsDto = appointments.Adapt<IReadOnlyCollection<AppointmentHistoryReadDto>>();
        return new CustomResult(true, HttpStatusCode.OK, appointmentsDto);
    }

    public async Task<ICustomResult> GetAppointmentsSchedule(Guid idDoctor, PageSettings pageSettings,
        AppointmentsScheduleFilter filter, CancellationToken cancellationToken)
    {
        var appointments = await _appointmentRepo.GetAppointmentsSchedule(idDoctor, pageSettings, filter, cancellationToken);
        var appointmentsDto = appointments.Adapt<IReadOnlyCollection<AppointmentScheduleReadDto>>();
        return new CustomResult(true, HttpStatusCode.OK, appointmentsDto);
    }

    public async Task<ICustomResult> CreateAppointment(AppointmentCreateDto appointmentCreateDto,
        CancellationToken cancellationToken)
    {
        var newAppointment = appointmentCreateDto.Adapt<Appointment>();
        newAppointment.IdAppointment = Guid.NewGuid();
        newAppointment.IsApproved = false;
        
        await _appointmentRepo.CreateAppointment(newAppointment, cancellationToken);
        return new CustomResult(true, HttpStatusCode.Created, newAppointment.IdAppointment);
    }

    public async Task<ICustomResult> UpdateAppointment(Guid idAppointment, AppointmentUpdateDto appointmentUpdateDto,
        CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepo.GetAppointmentById(idAppointment, cancellationToken); 
        if(appointment is null) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        if(appointment.IsApproved) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.CannotUpdateApprovedAppointment);
        
        appointmentUpdateDto.Adapt(appointment);
        await _appointmentRepo.UpdateAppointment(appointment, cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }

    public async Task<ICustomResult> UpdateAppointmentStatus(Guid idAppointment, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepo.GetAppointmentById(idAppointment, cancellationToken); 
        if(appointment is null) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        
        await _appointmentRepo.UpdateAppointmentField(
            !appointment.IsApproved, nameof(appointment.IsApproved),
            idAppointment, $"Id{nameof(Appointment)}",
            cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }

    public async Task<ICustomResult> DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentRepo.GetAppointmentById(idAppointment, cancellationToken); 
        if(appointment is null) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        
        await _appointmentRepo.DeleteAppointment(idAppointment, cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
}