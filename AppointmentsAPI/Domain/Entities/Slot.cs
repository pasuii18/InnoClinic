namespace Domain.Entities;

public class Slot
{
    public Guid IdSlot { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    public bool IsFree { get; set; } = true;
}