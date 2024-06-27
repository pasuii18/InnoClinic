namespace Application.Interfaces.ServicesInterfaces;

public interface IServiceCategoryService
{
    public Task<ICustomResult> GetServiceCategories(CancellationToken cancellationToken);
}