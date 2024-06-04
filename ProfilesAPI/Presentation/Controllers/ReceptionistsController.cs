using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Dtos.ReceptionistDtos;
using Application.Services.ReceptionistsFolder.Commands.DeleteReceptionist;
using Application.Services.ReceptionistsFolder.Queries.ViewReceptionistProfile;
using Application.Services.ReceptionistsFolder.Queries.ViewReceptionists;
using Microsoft.AspNetCore.Mvc;
using ProfilesAPI.Common;

namespace ProfilesAPI.Controllers;

[Route("api/v1/[controller]")]
public class ReceptionistsController : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetReceptionists(
        [FromQuery] PageSettings pageSettings, 
        [FromQuery] ReceptionistFilters receptionistFilters, CancellationToken cancellationToken)
    {
        var query = new ViewReceptionistsQuery
        {
            PageSettings = pageSettings, 
            ReceptionistFilters = receptionistFilters
        };
        var result = await Mediator.Send(query, cancellationToken);
        return Ok(result);
    }


    [HttpGet("{idReceptionist}")]
    public async Task<IActionResult> ViewReceptionistProfileQuery(
        Guid idReceptionist, CancellationToken cancellationToken)
    {
        var query = new ViewReceptionistProfileQuery { IdReceptionist = idReceptionist };
        var result = await Mediator.Send(query, cancellationToken);
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReceptionist(
        ReceptionistCreateDto receptionistCreateDto, CancellationToken cancellationToken)
    {
        var command = receptionistCreateDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateReceptionist(
        ReceptionistUpdateDto receptionistUpdateDto, CancellationToken cancellationToken)
    {
        var command = receptionistUpdateDto.MapInCommand();
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteReceptionist(
        Guid idReceptionist, CancellationToken cancellationToken)
    {
        var command = new DeleteReceptionistCommand { IdReceptionist = idReceptionist };
        var result = await Mediator.Send(command, cancellationToken);
        return Result(result);
    }
}