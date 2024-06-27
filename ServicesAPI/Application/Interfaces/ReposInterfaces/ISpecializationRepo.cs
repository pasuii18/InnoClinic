using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface ISpecializationRepo
{
    public Task<IReadOnlyCollection<Specialization>> GetSpecializations(
        Specification<Specialization> specification, CancellationToken cancellationToken);
    public Task<Specialization> GetSpecializationById(
        Specification<Specialization> specification, CancellationToken cancellationToken);
    public Task CreateSpecialization(Specialization specialization, CancellationToken cancellationToken);
    public Task DeleteSpecialization(Specialization specialization);
    public Task SaveChanges(CancellationToken cancellationToken);
}