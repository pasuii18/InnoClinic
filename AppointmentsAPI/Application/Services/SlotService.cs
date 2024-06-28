using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.SlotDtos;
using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Common;
using Domain.Entities;
using Mapster;

namespace Application.Services;

public class SlotService(ISlotRepo _slotRepo) : ISlotService
{
    public async Task<ICustomResult> GetAvailableDates(CancellationToken cancellationToken)
    {
        var dates = await _slotRepo.GetAvailableDates(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK, dates.AsReadOnly());
    }
    public async Task<ICustomResult> GetAvailableTimeSlotsOnDate(
        DateOnly date, int slotSize, CancellationToken cancellationToken)
    {
        var availableSlots = await _slotRepo.GetAvailableSlotsOnDate(date, cancellationToken);
        if(availableSlots.Count == 0)
            throw new Exception("There is no available slots today!");
        
        var availableSlotsDtos = new List<GetSlotDto>();
        var timeSlotSize = (availableSlots.First().EndTime - availableSlots.First().StartTime).Minutes;
        
        foreach (var slot in availableSlots)
        {
            if (AreConsecutiveSlotsFree(availableSlots, slot, slotSize))
            {
                var slotDto = 
                    new GetSlotDto(slot.Date, slot.StartTime, slot.EndTime.AddMinutes(timeSlotSize * (slotSize - 1)));
                availableSlotsDtos.Add(slotDto);
            }
        }
        if(availableSlotsDtos.Count == 0)
            throw new Exception($"There is no available slots on this date!");
        
        return new CustomResult(true, HttpStatusCode.OK, availableSlotsDtos.AsReadOnly());
    }
    public async Task<Slot> CheckReservationSlot(UpdateSlotStatusDto dto, Guid idAppointment, CancellationToken cancellationToken)
    {
        var requiredSlots = 
            await _slotRepo.GetSlotsByDateAndTime(dto.Date, dto.StartTime, dto.EndTime, cancellationToken);
        ValidateSlots(requiredSlots, dto.SlotSize, idAppointment);
        
        var slot = dto.Adapt<Slot>();
        slot.StartTime = requiredSlots.First().StartTime;
        slot.EndTime = requiredSlots.Last().EndTime;
        slot.IsFree = false;
        return slot;
    }
    private void ValidateSlots(IReadOnlyCollection<Slot> slots, int slotSize, Guid idAppointment)
    {
        if (slots.Count == 0)
            throw new Exception(Messages.TimeSlotsNotFound);
        
        if (slotSize != slots.Count)
            throw new Exception(Messages.NumberOfTimeSlotsIsNotValid);

        if (slots.Any(slot => slot.IsFree == false && slot.IdAppointment != idAppointment))
            throw new Exception(Messages.TimeSlotsReserved);
    }
    private bool AreConsecutiveSlotsFree(List<Slot> allSlots, Slot startSlot, int slotsSize)
    {
        int startIndex = allSlots.IndexOf(startSlot);
        for (int i = 0; i < slotsSize; i++)
        {
            int currentIndex = startIndex + i;
            if (currentIndex >= allSlots.Count ||
                (i > 0 && allSlots[currentIndex].StartTime != allSlots[currentIndex - 1].EndTime))
            {
                return false;
            }
        }
        return true;
    }
}