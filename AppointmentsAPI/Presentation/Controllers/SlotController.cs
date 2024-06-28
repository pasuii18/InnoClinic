using Application.Interfaces;
using Domain.Common;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common;

namespace ServicesAPI.Controllers;

[Route("api/v1/[controller]")]
public class SlotController(ISlotService _slotService) : CustomControllerBase
{
    [HttpGet("dates")]
    public async Task<IActionResult> GetAvailableDates(CancellationToken cancellationToken)
    {
        var result = await _slotService.GetAvailableDates(cancellationToken);
        return Result(result);
    }

    [HttpGet("{date}/{serviceType}")]
    public async Task<IActionResult> GetAvailableTimeSlotsOnDate(DateOnly date, int slotSize, 
        CancellationToken cancellationToken)
    {
        var result = await _slotService.GetAvailableTimeSlotsOnDate(date, slotSize, cancellationToken);
        return Result(result);
    }
}