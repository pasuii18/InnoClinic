using Application.Common;
using Application.Common.Specifications;
using Application.Interfaces.ReposInterfaces;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ServiceCategoryRepo(ServiceDbContext _context)
    : IServiceCategoryRepo
{
    public async Task<IReadOnlyCollection<ServiceCategory>> GetServiceCategories(
        Specification<ServiceCategory> specification, CancellationToken cancellationToken)
    {
        var serviceCategories = await _context.ServiceCategory.GetQuery(specification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return serviceCategories;
    }

    public async Task<ServiceCategory> GetServiceCategoryById(
        Specification<ServiceCategory> specification, CancellationToken cancellationToken)
    {
        var serviceCategory = await _context.ServiceCategory.GetQuery(specification)
            .FirstOrDefaultAsync(cancellationToken);
        return serviceCategory;
    }
}