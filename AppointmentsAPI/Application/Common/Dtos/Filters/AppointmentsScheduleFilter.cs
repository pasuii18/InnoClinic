using Application.Interfaces;
using Domain.Common;

namespace Application.Common.Dtos;

public record AppointmentsScheduleFilter(DateOnly Date, OrderType OrderType, OrderBy OrderBy) : IFilterBase;
    
// The table should be ordered ascending by time
// for doctors schedule