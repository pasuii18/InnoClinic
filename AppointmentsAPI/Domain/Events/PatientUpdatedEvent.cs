namespace Domain.Events;

public class PatientUpdatedEvent
{
    public Guid IdPatient { get; set; }
    public string PatientFullName { get; set; }
    public DateOnly PatientDateOfBirth { get; set; }
}