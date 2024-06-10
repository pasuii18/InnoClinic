using Application.Interfaces.ReposInterfaces;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SpecializationRepo(ServiceDbContext _context) 
    : ISpecializationRepo
{
    public async Task<IReadOnlyCollection<Specialization>> GetSpecializations(CancellationToken cancellationToken)
    {
        var specializations = await _context.Specialization
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return specializations;
    }

    public async Task<Specialization> GetSpecializationById(Guid idSpecialization, CancellationToken cancellationToken)
    {
        var specialization = await _context.Specialization
            .Include(spec => spec.Services)
                .ThenInclude(service => service.ServiceCategory)
            .FirstOrDefaultAsync(spec => spec.IdSpecialization == idSpecialization, cancellationToken);
        return specialization;
    }

    public async Task CreateSpecialization(Specialization specialization, CancellationToken cancellationToken)
    {
        await _context.Specialization.AddAsync(specialization, cancellationToken);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}