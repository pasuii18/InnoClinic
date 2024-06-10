using Application.Interfaces.ReposInterfaces;
using Application.Interfaces.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;
using ServicesAPI.Common;

namespace ServicesAPI.Controllers;

[Route("api/v1/[controller]")]
public class ServiceCategoriesController(IServiceCategoryService _serviceCategoryService)
    : CustomControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetServiceCategories(CancellationToken cancellationToken)
    {
        var result = await _serviceCategoryService.GetServiceCategories(cancellationToken);
        return Result(result);
    }
}