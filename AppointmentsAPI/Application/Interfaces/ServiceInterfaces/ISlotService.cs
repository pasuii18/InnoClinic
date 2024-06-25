using Application.Common.Dtos;
using Domain.Common;

namespace Application.Interfaces;

public interface ISlotService
{
    public Task<ICustomResult> GetAvailableDates(CancellationToken cancellationToken);
    public Task<ICustomResult> GetAvailableTimeSlotsOnDate(
        DateOnly date, ServiceType serviceType, CancellationToken cancellationToken);
    public Task CreateSlots(DateOnly startDate, DateOnly endDate,
        TimeOnly startDayTime, TimeOnly endDayTime, int timeSlotSize, CancellationToken cancellationToken);
    public Task ChangeSlotStatus(DateOnly date, TimeOnly startTime, TimeOnly endTime, ServiceType serviceType,
        bool status, CancellationToken cancellationToken);
}