namespace Application.Common.Dtos.ResultDtos;

public class ResultCreateDto
{
    // public DateOnly DateOfResult { get; set; }
    // public string PatientFullName { get; set; }
    // public DateTime PatientDateOfBirth { get; set; }
    // public string DoctorFullName { get; set; }
    // public string SpecializationName { get; set; }
    // public string ServiceName { get; set; }
    // public string Complaints { get; set; }
    // public string Conclusion { get; set; }
    // public string Recommendations { get; set; }
    public string Complaints { get; set; }
    public string Conclusion { get; set; }
    public string Recommendations { get; set; }
    public Guid IdAppointment { get; set; }
}