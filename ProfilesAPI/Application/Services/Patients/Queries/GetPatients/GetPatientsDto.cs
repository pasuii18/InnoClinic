using Domain.Entities;

namespace Application.Common.Dtos.PatientDtos;

public record GetPatientsDto(IReadOnlyCollection<GetPatientProfileDto> Patients)
{
    public static GetPatientsDto MapFromPatients(IReadOnlyCollection<Patient> patients)
    {
        return new GetPatientsDto(patients.Select(GetPatientProfileDto.MapFromPatient).ToList().AsReadOnly());
    }
}