using Application.Interfaces;
using Domain.Common;

namespace Application.Common.Dtos.Filters;

public record AppointmentsFilter(DateOnly? Date, string? DoctorFullName, string? ServiceName,
    AppointmentStatus IsApproved, Guid? IdOffice);