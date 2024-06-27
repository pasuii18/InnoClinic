using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IReceptionistsRepo
{
    public Task<IReadOnlyCollection<Receptionist>> GetReceptionists(
        ReceptionistFilters filters, PageSettings pageSettings, CancellationToken cancellationToken);
    public Task<Receptionist> GetReceptionistById(
        Guid idReceptionist, CancellationToken cancellationToken);
    public Task CreateReceptionist(
        Receptionist receptionist, CancellationToken cancellationToken);
    public Task UpdateReceptionist(
        Receptionist receptionist, CancellationToken cancellationToken);
    public Task DeleteReceptionist(
        Guid idReceptionist, CancellationToken cancellationToken);
}