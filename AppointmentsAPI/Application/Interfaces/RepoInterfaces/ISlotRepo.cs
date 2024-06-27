using Domain.Entities;

namespace Application.Interfaces.RepoInterfaces;

public interface ISlotRepo
{
    public Task<List<DateOnly>> GetDates(CancellationToken cancellationToken);
    public Task<List<DateOnly>> GetAvailableDates(CancellationToken cancellationToken);
    public Task<List<Slot>> GetAvailableSlotsOnDate(DateOnly date, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Slot>> GetSlotsByDateAndTime(DateOnly date, TimeOnly startTime,
        TimeOnly endTime, CancellationToken cancellationToken);
    public Task ScheduleSlots(List<Slot> slots, List<DateOnly> dates, CancellationToken cancellationToken);
}