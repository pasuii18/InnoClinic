namespace Domain.Events.DoctorEvents;

public class DoctorUpdatedEvent
{
    public Guid IdDoctor { get; set; }
    public string DoctorFullName { get; set; }
}