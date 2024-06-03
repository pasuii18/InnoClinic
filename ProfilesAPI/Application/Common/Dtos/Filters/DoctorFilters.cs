namespace Application.Common.Dtos.Filters;

public record DoctorFilters(
    string? FullName, 
    Guid? IdSpecialization, 
    Guid? IdOffice);