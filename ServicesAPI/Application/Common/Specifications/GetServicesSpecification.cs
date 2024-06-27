using System.Linq.Expressions;
using Application.Common.Dtos;
using Application.Common.Dtos.Filters;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Specifications;

public class GetServicesSpecification : Specification<Service>
{
    public GetServicesSpecification(PageSettings pageSettings, ServicesFilter servicesFilter)
        : base(service => 
            service.IdServiceCategory == servicesFilter.IdServiceCategory 
            && service.IsActive 
            && service.Specialization != null 
            && service.Specialization.IsActive)
    {
        AddInclude(inc => inc.Include(service => service.Specialization!));
        AddOrderBy(service => service.IdService);
        AddSkip((pageSettings.Page - 1) * pageSettings.PageSize);
        AddTake(pageSettings.PageSize);
    }
}