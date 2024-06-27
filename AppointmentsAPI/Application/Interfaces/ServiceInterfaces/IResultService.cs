using Application.Common.Dtos.ResultDtos;

namespace Application.Interfaces;

public interface IResultService
{
    // US-60, US-61
    public Task<ICustomResult> GetAppointmentResult(Guid idAppointment, CancellationToken cancellationToken);
    // US-58
    public Task<ICustomResult> CreateResult(ResultCreateDto resultCreateDto, CancellationToken cancellationToken);
    // US-59
    public Task<ICustomResult> UpdateResult(Guid idResult, ResultUpdateDto resultUpdateDto, CancellationToken cancellationToken);
    // US-62 ?
    public Task<ICustomResult> DownloadResult(Guid idResult, CancellationToken cancellationToken);
}