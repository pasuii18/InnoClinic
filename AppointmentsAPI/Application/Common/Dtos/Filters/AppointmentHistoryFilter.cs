using Application.Interfaces;
using Domain.Common;

namespace Application.Common.Dtos.Filters;

public record AppointmentHistoryFilter(DateOnly Date, OrderBy OrderBy, OrderType OrderType) : IFilterBase;

// The table should be ordered descending by date
// + equal dates Then this appointments should be ordered ascending by time