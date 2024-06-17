﻿namespace Application.Common.Dtos.AppointmentsDtos;

public record AppointmentScheduleReadDto(Guid IdAppointment, DateOnly Date, TimeOnly Time, 
    string PatientFullName, Guid IdPatient, string ServiceName, bool IsApproved);