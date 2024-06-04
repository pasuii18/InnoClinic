using Domain;

namespace Application.Common.Dtos.Filters;

public record DoctorFilters(
    OrderBy OrderBy,
    OrderType OrderType,
    string? FullName, 
    DoctorStatus Status,
    Guid? IdSpecialization, 
    Guid? IdOffice);