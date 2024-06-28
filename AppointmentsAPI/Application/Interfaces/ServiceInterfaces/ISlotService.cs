using Application.Common.Dtos;
using Application.Common.Dtos.SlotDtos;
using Domain.Common;
using Domain.Entities;

namespace Application.Interfaces;

public interface ISlotService
{
    public Task<ICustomResult> GetAvailableDates(CancellationToken cancellationToken);
    public Task<ICustomResult> GetAvailableTimeSlotsOnDate(DateOnly date, int slotSize, CancellationToken cancellationToken);
    public Task<Slot> CheckReservationSlot(UpdateSlotStatusDto dto, Guid idAppointment, CancellationToken cancellationToken);
}