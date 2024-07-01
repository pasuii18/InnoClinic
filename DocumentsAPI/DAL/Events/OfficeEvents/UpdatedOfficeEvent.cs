namespace DAL.Events.OfficeEvents;

public class UpdatedOfficeEvent
{
    public Guid IdOffice { get; set; }
    public byte[] Data { get; set; }
}