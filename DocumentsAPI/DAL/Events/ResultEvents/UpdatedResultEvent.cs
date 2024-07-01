namespace DAL.Events.ResultEvents;

public class UpdatedResultEvent
{
    public Guid IdResult { get; set; }
    public byte[] Data { get; set; }
}