namespace Domain.Events.ServiceEvents;

public class ServiceUpdatedEvent
{
    public Guid IdService { get; set; }
    public string ServiceName { get; set; }
    public string SpecializationName { get; set; }
}