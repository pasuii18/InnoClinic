namespace DAL.Events.AccountEvents;

public class UpdatedAccountEvent
{
    public Guid IdAccount { get; set; }
    public byte[] Data { get; set; }
}