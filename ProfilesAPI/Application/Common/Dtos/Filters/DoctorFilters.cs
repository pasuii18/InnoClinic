using Application.Interfaces;
using Domain;
using Domain.Common.Enums;

namespace Application.Common.Dtos.Filters;

public record DoctorFilters(OrderBy OrderBy, OrderType OrderType, string? FullName, DoctorStatus Status,
    Guid? IdSpecialization, Guid? IdOffice) 
    : IFiltersBase;