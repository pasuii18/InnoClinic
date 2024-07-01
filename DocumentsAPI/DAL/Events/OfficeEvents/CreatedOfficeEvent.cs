namespace DAL.Events.OfficeEvents;

public class CreatedOfficeEvent
{
    public Guid IdOffice { get; set; }
    public byte[] Data { get; set; }
}