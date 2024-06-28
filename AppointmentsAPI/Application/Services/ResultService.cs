using System.Net;
using Application.Common;
using Application.Common.Dtos.ResultDtos;
using Application.Interfaces;
using Application.Interfaces.RepoInterfaces;
using Domain.Entities;
using Mapster;

namespace Application.Services;

public class ResultService(IResultRepo _resultRepo, IAppointmentReadRepo _appointmentReadRepo) : IResultService
{
    public async Task<ICustomResult> GetAppointmentResult(Guid idAppointment, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultByAppointmentId(idAppointment, cancellationToken);
        if (result is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultNotFound);
        
        var resultDto = result.Adapt<GetResultDto>();
        return new CustomResult(true, HttpStatusCode.OK, resultDto);
    }

    public async Task<ICustomResult> CreateResult(CreateResultDto createResultDto, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultByAppointmentId(createResultDto.IdAppointment, cancellationToken);
        if (result is not null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultAlreadyExists);
        
        var appointment = await _appointmentReadRepo.GetAppointmentById(createResultDto.IdAppointment, cancellationToken);
        if (appointment is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.AppointmentNotFound);
        
        var newResult = createResultDto.Adapt<Result>();
        newResult.IdResult = Guid.NewGuid();
        newResult.Date = DateOnly.FromDateTime(DateTime.Now);
        await _resultRepo.CreateResult(newResult, cancellationToken);
        return new CustomResult(true, HttpStatusCode.Created, newResult.IdResult);
    }
    public async Task<ICustomResult> UpdateResult(Guid idResult, UpdateResultDto updateResultDto, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultById(idResult, cancellationToken);
        if (result is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultNotFound);
        
        updateResultDto.Adapt(result);
        await _resultRepo.UpdateResult(result, cancellationToken);
        return new CustomResult(true, HttpStatusCode.OK);
    }
    public async Task<ICustomResult> DownloadResult(Guid idResult, CancellationToken cancellationToken)
    {
        var result = await _resultRepo.GetResultById(idResult, cancellationToken);
        if (result is null)
            return new CustomResult(false, HttpStatusCode.NotFound, Messages.ResultNotFound);
        
        var resultDto = result.Adapt<GetResultDto>();
        
        var pdfBytes = PdfGenerator.GeneratePdf(resultDto);
        
        return new CustomResult(true, HttpStatusCode.OK, pdfBytes);
    }
}