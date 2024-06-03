using Application.Common.Dtos;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IReceptionistsRepo
{
    public Task<IReadOnlyCollection<Receptionist>> GetReceptionists(
        PageSettings pageSettings, CancellationToken cancellationToken);
    public Task<Receptionist> GetReceptionistById(
        Guid idReceptionist, CancellationToken cancellationToken);
    public Task CreateReceptionist(
        Receptionist patient, CancellationToken cancellationToken);
    public Task DeleteReceptionist(
        Guid idReceptionist, CancellationToken cancellationToken);
}