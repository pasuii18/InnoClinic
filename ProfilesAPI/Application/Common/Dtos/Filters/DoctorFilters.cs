namespace Application.Common.Dtos.Filters;

public record DoctorFilters(
    string? FullName, 
    Guid? Specialization, 
    Guid? IdOffice);