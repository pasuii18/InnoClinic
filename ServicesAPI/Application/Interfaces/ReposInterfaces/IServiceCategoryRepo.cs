using Domain.Entities;

namespace Application.Interfaces.ReposInterfaces;

public interface IServiceCategoryRepo
{
    public Task<IReadOnlyCollection<ServiceCategory>> GetServiceCategories(CancellationToken cancellationToken);
    public Task<ServiceCategory> GetServiceCategoryById(Guid idServiceCategory, CancellationToken cancellationToken);
}