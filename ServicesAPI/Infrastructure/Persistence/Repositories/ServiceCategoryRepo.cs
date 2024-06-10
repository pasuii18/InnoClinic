using Application.Interfaces.ReposInterfaces;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ServiceCategoryRepo(ServiceDbContext _context)
    : IServiceCategoryRepo
{
    public async Task<IReadOnlyCollection<ServiceCategory>> GetServiceCategories(CancellationToken cancellationToken)
    {
        var serviceCategories = await _context.ServiceCategory
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return serviceCategories;
    }

    public async Task<ServiceCategory> GetServiceCategoryById(Guid idServiceCategory, CancellationToken cancellationToken)
    {
        var serviceCategory = await _context.ServiceCategory
            .FirstOrDefaultAsync(service => service.IdServiceCategory == idServiceCategory, cancellationToken);
        return serviceCategory;
    }
}