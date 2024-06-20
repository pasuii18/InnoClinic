using Application.Interfaces;
using Domain.Common;

namespace Application.Common.Dtos.Filters;

public record AppointmentsScheduleFilter(DateOnly Date);