using System.Net;
using Application.Common;
using Application.Common.Dtos;
using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Common;
using Domain.Entities;

namespace Application.Services;

public class SlotService(ISlotRepo _slotRepo) : ISlotService
{
    public async Task<ICustomResult> GetAvailableDates(CancellationToken cancellationToken)
    {
        var dates = await _slotRepo.GetAvailableDates(cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK, dates.AsReadOnly());
    }
    public async Task<ICustomResult> GetAvailableTimeSlotsOnDate(
        DateOnly date, ServiceType serviceType, CancellationToken cancellationToken)
    {
        var availableSlots = await _slotRepo.GetAvailableSlotsOnDate(date, cancellationToken);
        if(availableSlots.Count == 0)
            throw new Exception("There is no available slots today!");
        
        var availableSlotsDtos = new List<SlotReadDto>();
        var slotsSize = GetSlotsSize(serviceType);
        var timeSlotSize = (availableSlots.First().EndTime - availableSlots.First().StartTime).Minutes;
        
        foreach (var slot in availableSlots)
        {
            if (AreConsecutiveSlotsFree(availableSlots, slot, slotsSize))
            {
                var slotDto = 
                    new SlotReadDto(slot.Date, slot.StartTime, slot.EndTime.AddMinutes(timeSlotSize * (slotsSize - 1)));
                availableSlotsDtos.Add(slotDto);
            }
        }
        if(availableSlotsDtos.Count == 0)
            throw new Exception($"There is no available slots on this date for {serviceType}!");
        
        return new CustomResult(true, HttpStatusCode.OK, availableSlotsDtos.AsReadOnly());
    }
    public async Task CreateSlots(DateOnly startDate, DateOnly endDate, 
        TimeOnly startDayTime, TimeOnly endDayTime, int timeSlotSize, CancellationToken cancellationToken)
    {
        var slots = new List<Slot>();
        
        for (var currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
        {
            for (var currentTime = startDayTime; currentTime.AddMinutes(timeSlotSize) <= endDayTime; 
                 currentTime = currentTime.AddMinutes(timeSlotSize))
            {
                slots.Add(new Slot { IdSlot = Guid.NewGuid(), Date = currentDate,
                    StartTime = currentTime, EndTime = currentTime.AddMinutes(timeSlotSize) });
            }
        }
        
        await _slotRepo.CreateSlots(slots, cancellationToken);
    }
    public async Task ChangeSlotStatus(DateOnly date, TimeOnly startTime, TimeOnly endTime, ServiceType serviceType, 
        bool status, CancellationToken cancellationToken)
    {
        var requiredSlots = await _slotRepo.GetSlotsByDateAndTime(date, startTime, endTime, cancellationToken);
        ValidateSlots(requiredSlots, serviceType, status);
        await _slotRepo.ChangeSlotsStatuses(date, startTime, endTime, status, cancellationToken);
    }
    private void ValidateSlots(IReadOnlyCollection<Slot> slots, ServiceType serviceType, bool shouldBeFree)
    {
        if (slots.Count == 0)
            throw new Exception("Time slots not found!");

        if (slots.Count != GetSlotsSize(serviceType))
            throw new Exception("Required slots count does not match!");

        if (slots.Any(slot => slot.IsFree == shouldBeFree))
            throw new Exception($"Time slots are{(shouldBeFree ? " not" : " already")} reserved!");
    }
    private int GetSlotsSize(ServiceType serviceType)
    {
        return serviceType switch
        {
            ServiceType.Analyses => 1,
            ServiceType.Consultation => 2,
            ServiceType.Diagnostics => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(serviceType), "Unknown service type")
        };
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