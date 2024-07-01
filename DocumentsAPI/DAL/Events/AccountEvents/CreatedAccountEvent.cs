namespace DAL.Events.AccountEvents;

public class CreatedAccountEvent
{
    public Guid IdAccount { get; set; }
    public byte[] Data { get; set; }
}