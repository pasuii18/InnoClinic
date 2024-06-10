using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Interfaces.ReposInterfaces;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ServiceRepo(ServiceDbContext _context) 
    : IServiceRepo
{
    public async Task<IReadOnlyCollection<Service>> GetServices(PageSettings pageSettings, 
        ServicesFilter servicesFilter, CancellationToken cancellationToken)
    {
        var query = _context.Service
            .Include(service => service.Specialization)
            .Where(service => 
                service.IdServiceCategory == servicesFilter.IdServiceCategory && 
                service.IsActive && 
                service.Specialization != null && 
                service.Specialization.IsActive);

        query = query
            .OrderBy(service => service.IdService)
            .Skip((pageSettings.Page - 1) * pageSettings.PageSize)
            .Take(pageSettings.PageSize)
            .AsNoTracking();
        
        var services = await query.ToListAsync(cancellationToken);
        
        return services;
    }

    public async Task<Service> GetServiceById(Guid idService, CancellationToken cancellationToken)
    {
        var service = await _context.Service
            .Include(service => service.ServiceCategory)
            .FirstOrDefaultAsync(service => service.IdService == idService, cancellationToken);
        return service;
    }

    public async Task CreateService(Service service, CancellationToken cancellationToken)
    {
        await _context.Service.AddAsync(service, cancellationToken);
    }

    public async Task SaveChanges(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}