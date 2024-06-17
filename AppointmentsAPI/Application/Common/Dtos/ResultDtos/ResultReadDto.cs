namespace Application.Common.Dtos.ResultDtos;

public class ResultReadDtoByDoctor
{
    public Guid IdResult { get; set; }
    public DateOnly DateOfResult { get; set; }
    public string PatientFullName { get; set; }
    public DateTime PatientDateOfBirth { get; set; }
    public string DoctorFullName { get; set; }
    public string SpecializationName { get; set; }
    public string ServiceName { get; set; }
    public string Complaints { get; set; }
    public string Conclusion { get; set; }
    public string Recommendations { get; set; }
}
// us-60