using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.SlotDtos;
using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Entities;
using Domain.Events;
using Domain.Events.DoctorEvents;
using Domain.Events.ServiceEvents;
using Mapster;
using MassTransit;

namespace Application.Services;

public class AppointmentWriteService(IAppointmentWriteRepo _appointmentWriteRepo,
    IAppointmentReadRepo _appointmentReadRepo, IPublishEndpoint _publishEndpoint, ISlotService _slotService) 
    : IAppointmentWriteService
{
    public async Task<ICustomResult> CreateAppointment(CreateAppointmentDto createAppointmentDto,
        CancellationToken cancellationToken)
    {
        var newAppointment = createAppointmentDto.Adapt<Appointment>();
        var slot = await _slotService.CheckReservationSlot(createAppointmentDto.UpdateSlotStatusDto, 
            newAppointment.IdAppointment, cancellationToken);
        slot.Adapt(newAppointment);
        
        await _appointmentWriteRepo.CreateAppointment(newAppointment, cancellationToken);
        await PublishAppointmentEvents(newAppointment, cancellationToken);
        
        return new CustomResult(true, HttpStatusCode.Created, newAppointment.IdAppointment);
    }
    public async Task<ICustomResult> UpdateAppointment(Guid idAppointment, UpdateAppointmentDto updateAppointmentDto,
        CancellationToken cancellationToken)
    {
        var appointment = await _appointmentReadRepo.GetAppointmentById(idAppointment, cancellationToken); 
        if(appointment is null) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        if(appointment.IsApproved) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.CannotUpdateApprovedAppointment);

        var dto = updateAppointmentDto.Adapt<UpdateSlotStatusDto>();
        var newSlot = await _slotService.CheckReservationSlot(dto, idAppointment, cancellationToken);
        
        var newAppointment = appointment.Adapt<Appointment>();
        newSlot.Adapt(newAppointment);
        newAppointment.IdDoctor = updateAppointmentDto.IdDoctor;
        
        await _appointmentWriteRepo.UpdateAppointmentAndSlot(appointment, newAppointment, cancellationToken);
        await PublishAppointmentEvents(appointment, cancellationToken, false);
        
        return new CustomResult(true, HttpStatusCode.OK);
    }
    public async Task<ICustomResult> UpdateAppointmentStatus(Guid idAppointment, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentReadRepo.GetAppointmentById(idAppointment, cancellationToken); 
        if(appointment is null) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        
        await _appointmentWriteRepo.UpdateAppointmentField(
            !appointment.IsApproved, nameof(appointment.IsApproved),
            idAppointment, $"Id{nameof(Appointment)}",
            cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
    public async Task<ICustomResult> DeleteAppointment(Guid idAppointment, CancellationToken cancellationToken)
    {
        var appointment = await _appointmentReadRepo.GetAppointmentById(idAppointment, cancellationToken); 
        if(appointment is null) 
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        
        await _appointmentWriteRepo.DeleteAppointment(appointment, cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
    
    private async Task PublishAppointmentEvents(Appointment appointment, CancellationToken cancellationToken, bool isNew = true)
    {
        var appointmentDoctorEvent = new AppointmentDoctorUpdateEvent(appointment.IdDoctor);
        await _publishEndpoint.Publish(appointmentDoctorEvent, cancellationToken);

        if (isNew)
        {
            var appointmentPatientEvent = new AppointmentPatientUpdateEvent(appointment.IdPatient);
            var appointmentServiceEvent = new AppointmentServiceUpdateEvent(appointment.IdService);
            await _publishEndpoint.Publish(appointmentPatientEvent, cancellationToken);
            await _publishEndpoint.Publish(appointmentServiceEvent, cancellationToken);
        }
    }
}