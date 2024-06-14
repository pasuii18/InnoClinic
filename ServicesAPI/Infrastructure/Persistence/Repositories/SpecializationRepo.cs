using Application.Common;
using Application.Common.Specifications;
using Application.Interfaces.ReposInterfaces;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SpecializationRepo(ServiceDbContext _context) 
    : ISpecializationRepo
{
    public async Task<IReadOnlyCollection<Specialization>> GetSpecializations(
        Specification<Specialization> specification, CancellationToken cancellationToken)
    {
        var specializations = await _context.Specialization.GetQuery(specification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return specializations;
    }

    public async Task<Specialization> GetSpecializationById(
        Specification<Specialization> specification, CancellationToken cancellationToken)
    {
        var specialization = await _context.Specialization.GetQuery(specification)
            .FirstOrDefaultAsync(cancellationToken);
        return specialization;
    }

    public async Task CreateSpecialization(Specialization specialization, CancellationToken cancellationToken)
    {
        await _context.Specialization.AddAsync(specialization, cancellationToken);
    }

    public async Task DeleteSpecialization(Specialization specialization)
    {
        _context.Specialization.Remove(specialization);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}