using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface ISpecializationRepo
{
    public Task<IReadOnlyCollection<Specialization>> GetSpecializations(CancellationToken cancellationToken);
    public Task<Specialization> GetSpecializationById(Guid idSpecialization, CancellationToken cancellationToken);
    public Task CreateSpecialization(Specialization specialization, CancellationToken cancellationToken);
    public Task SaveChanges(CancellationToken cancellationToken);
}