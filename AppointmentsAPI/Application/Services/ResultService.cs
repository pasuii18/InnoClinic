using System.Net;
using Application.Common;
using Application.Common.Dtos.ResultDtos;
using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Entities;
using Mapster;

namespace Application.Services;

public class ResultService(IResultRepo _resultRepo, IAppointmentRepo _appointmentRepo) : IResultService
{
    public async Task<ICustomResult> GetAppointmentResult(Guid idAppointment, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultByAppointmentId(idAppointment, cancellationToken);
        if (result is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultNotFound);
        
        var resultDto = result.Adapt<ResultReadDto>();
        return new CustomResult(true, HttpStatusCode.OK, resultDto);
    }

    public async Task<ICustomResult> CreateResult(ResultCreateDto resultCreateDto, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultByAppointmentId(resultCreateDto.IdAppointment, cancellationToken);
        if (result is not null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultAlreadyExists);
        var appointment = await _appointmentRepo.GetAppointmentsById(resultCreateDto.IdAppointment, cancellationToken);
        if (appointment is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        
        var newResult = resultCreateDto.Adapt<Result>();
        newResult.IdResult = Guid.NewGuid();
        await _resultRepo.CreateResult(newResult, cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK, newResult.IdResult);
    }

    public async Task<ICustomResult> UpdateResult(ResultUpdateDto resultUpdateDto, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultById(resultUpdateDto.IdResult, cancellationToken);
        if (result is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultNotFound);
        
        resultUpdateDto.Adapt(result);
        await _resultRepo.UpdateResult(result, cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }

    public async Task<ICustomResult> DownloadResult(Guid idResult, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultById(idResult, cancellationToken);
        if (result is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultNotFound);
        
        var resultDto = result.Adapt<ResultReadDto>();
        
        var pdfBytes = PdfGenerator.GeneratePdf(resultDto);
        // var filePath = Path.Combine("C:\\Users\\Ihar\\Desktop", $"Result_{Guid.NewGuid()}.pdf");
        // File.WriteAllBytes(filePath, pdfBytes);
        
        return new CustomResult(true, HttpStatusCode.OK, pdfBytes);
    }
}