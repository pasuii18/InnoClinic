namespace DAL.Events.ResultEvents;

public class CreatedResultEvent
{
    public Guid IdResult { get; set; }
    public byte[] Data { get; set; }
}