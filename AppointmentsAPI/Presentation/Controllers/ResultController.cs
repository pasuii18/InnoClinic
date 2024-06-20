using Application.Common;
using Application.Common.Dtos.AppointmentsDtos;
using Application.Common.Dtos.ResultDtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;

namespace ServicesAPI.Controllers;

[Route("api/v1/[controller]")]
public class ResultController(IResultService _resultService) : CustomControllerBase
{
    [HttpGet("{idAppointment}")]
    public async Task<IActionResult> GetAppointmentResult(Guid idAppointment, CancellationToken cancellationToken)
    {
        var result = await _resultService.GetAppointmentResult(idAppointment, cancellationToken);
        return Result(result);
    }
        
    [HttpGet("download/{idResult}")]
    public async Task<IActionResult> DownloadResult(Guid idResult, CancellationToken cancellationToken)
    {
        var result = await _resultService.DownloadResult(idResult, cancellationToken);
        // return File(result.Data as byte[], "application/pdf", "Result.pdf");
        return Result(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateResult([FromBody][AutoValidateAlways]ResultCreateDto resultCreateDto,
        CancellationToken cancellationToken)
    {
        var result = await _resultService.CreateResult(resultCreateDto, cancellationToken);
        return Result(result);
    }
    
    [HttpPut("{idResult}")]
    public async Task<IActionResult> UpdateResult(Guid idResult, 
        [FromBody][AutoValidateAlways]ResultUpdateDto resultUpdateDto,
        CancellationToken cancellationToken)
    {
        var result = await _resultService.UpdateResult(idResult, resultUpdateDto, cancellationToken);
        return Result(result);
    }
}