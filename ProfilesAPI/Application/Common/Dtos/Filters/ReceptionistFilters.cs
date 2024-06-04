using Application.Interfaces;
using Domain;
using Domain.Common.Enums;

namespace Application.Common.Dtos.Filters;

public record ReceptionistFilters(OrderBy OrderBy, OrderType OrderType, string? FullName) 
    : IFiltersBase;