using Domain.Entities;

namespace Application.Common.Dtos.PatientDtos;

public record GetPatientProfileDto(
    Guid IdPatient, string FirstName, string LastName, string MiddleName, DateTime DateOfBirth)
{
    public static GetPatientProfileDto MapFromPatient(Patient patient)
    {
        return new GetPatientProfileDto(
            patient.IdPatient, patient.FirstName, patient.LastName, patient.MiddleName, patient.DateOfBirth);
    }
}