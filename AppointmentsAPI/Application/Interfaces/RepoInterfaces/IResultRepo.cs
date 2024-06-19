using Application.Common.Dtos.ResultDtos;
using Domain.Entities;

namespace Application.Interfaces.RepoInterfaces;

public interface IResultRepo
{
    public Task<Result> GetResultById(Guid idAppointment, CancellationToken cancellationToken);
    public Task<Result> GetResultByAppointmentId(Guid idAppointment, CancellationToken cancellationToken);
    public Task CreateResult(Result result, CancellationToken cancellationToken);
    public Task UpdateResult(Result result, CancellationToken cancellationToken);
}