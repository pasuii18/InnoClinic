using Domain.Entities;

namespace Application.Common.Dtos.PatientDtos;

public record PatientReadDto(
    Guid IdPatient, string FirstName, string LastName, string MiddleName, DateOnly DateOfBirth)
{
    public static PatientReadDto MapFromPatient(Patient patient)
    {
        return new PatientReadDto(
            patient.IdPatient, patient.FirstName, patient.LastName, patient.MiddleName, patient.DateOfBirth);
    }
}