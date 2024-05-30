using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IReceptionistsRepo
{
    public Task<IReadOnlyCollection<Receptionist>> GetReceptionists();
    public Task<Receptionist> GetReceptionistById(Guid idReceptionist);
    public Task CreateReceptionist(Receptionist patient);
    public Task DeleteReceptionist(Receptionist patient);
}