using Application.Interfaces.ReposInterfaces;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ServiceRepo(ServiceDbContext _context) 
    : IServiceRepo
{
    public async Task<IReadOnlyCollection<Service>> GetServices(CancellationToken cancellationToken)
    {
        var services = await _context.Service
            .AsNoTracking()
            .ToListAsync(cancellationToken);
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
}