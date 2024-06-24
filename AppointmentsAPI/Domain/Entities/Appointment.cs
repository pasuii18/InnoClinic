using Microsoft.VisualBasic;

namespace Domain.Entities;

public class Appointment
{
    public Guid IdAppointment { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public bool IsApproved { get; set; }
    public Guid IdPatient { get; set; }
    public Guid IdDoctor { get; set; }
    public Guid IdService { get; set; }
    public Result? Result { get; set; }
    public string? DoctorFullName { get; set; }
    public string? PatientFullName { get; set; }
    public DateOnly? PatientDateOfBirth { get; set; }
    public string? PatientPhoneNumber { get; set; }
    public string? ServiceName { get; set; }
    public string? SpecializationName { get; set; }
}