namespace Application.Common.Dtos.ResultDtos;

public record ResultReadDto(
    Guid IdResult,
    DateOnly Date,
    string PatientFullName,
    DateOnly PatientDateOfBirth,
    string DoctorFullName,
    string SpecializationName,
    string ServiceName,
    string Complaints,
    string Conclusion,
    string Recommendations);
// us-60