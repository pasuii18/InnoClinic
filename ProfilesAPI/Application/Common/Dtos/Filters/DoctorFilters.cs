using Application.Interfaces;
using Domain.Common.Enums;

namespace Application.Common.Dtos.Filters;

public record DoctorFilters(OrderBy OrderBy, OrderType OrderType, string? FullName, DoctorStatus Status,
    Guid? IdSpecialization, string? IdOffice) 
    : IFiltersBase;