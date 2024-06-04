using Domain;

namespace Application.Common.Dtos.Filters;

public record PatientFilters(OrderBy OrderBy, OrderType OrderType, string? FullName);