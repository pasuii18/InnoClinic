using Application.Common;
using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Application.Common.Specifications;
using Application.Interfaces.ReposInterfaces;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ServiceRepo(ServiceDbContext _context) 
    : IServiceRepo
{
    public async Task<IReadOnlyCollection<Service>> GetServices(
        Specification<Service> specification,  CancellationToken cancellationToken)
    {
        var services = await _context.Service.GetQuery(specification)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
        return services;
    }

    public async Task<Service> GetServiceById(
        Specification<Service> specification,  CancellationToken cancellationToken)
    {
        var service = await _context.Service.GetQuery(specification)
            .FirstOrDefaultAsync(cancellationToken);
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