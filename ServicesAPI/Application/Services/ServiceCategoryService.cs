using System.Net;
using Application.Common;
using Application.Common.Dtos.ServiceCategoryDtos;
using Application.Common.Dtos.ServiceDtos;
using Application.Interfaces;
using Application.Interfaces.ReposInterfaces;
using Application.Interfaces.ServicesInterfaces;
using Mapster;

namespace Application.Services;

public class ServiceCategoryService(IServiceCategoryRepo _serviceCategoryRepo)
    : IServiceCategoryService
{
    public async Task<ICustomResult> GetServiceCategories(CancellationToken cancellationToken)
    {
        var serviceCategories = await _serviceCategoryRepo.GetServiceCategories(cancellationToken);
        var serviceCategoriesDtos = serviceCategories.Adapt<IReadOnlyCollection<ServiceCategoryReadDto>>();
        return new CustomResult(true, HttpStatusCode.OK, serviceCategoriesDtos);
    }
}