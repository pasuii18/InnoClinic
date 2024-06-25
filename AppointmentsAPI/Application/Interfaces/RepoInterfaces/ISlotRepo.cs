using Domain.Entities;

namespace Application.Interfaces.RepoInterfaces;

public interface ISlotRepo
{
    public Task<List<DateOnly>> GetAvailableDates(CancellationToken cancellationToken);
    public Task<List<Slot>> GetAvailableSlotsOnDate(DateOnly date, CancellationToken cancellationToken);
    public Task<IReadOnlyCollection<Slot>> GetSlotsByDateAndTime(DateOnly date, TimeOnly startTime,
        TimeOnly endTime, CancellationToken cancellationToken);
    public Task CreateSlots(List<Slot> slots, CancellationToken cancellationToken);
    public Task ChangeSlotsStatuses(DateOnly date, TimeOnly startTime, TimeOnly endTime, bool status,
        CancellationToken cancellationToken);
}