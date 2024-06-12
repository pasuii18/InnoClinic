using System.Linq.Expressions;
using Application.Common;
using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IServiceCategoryRepo 
{
    public Task<IReadOnlyCollection<ServiceCategory>> GetServiceCategories(
        Specification<ServiceCategory> specification, CancellationToken cancellationToken);
    public Task<ServiceCategory> GetServiceCategoryById(
        Specification<ServiceCategory> specification, CancellationToken cancellationToken);
}