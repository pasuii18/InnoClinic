namespace Application.Common.Dtos.Filters;

public record PatientFilters(string OrderBy, bool OrderType, string? FullName);