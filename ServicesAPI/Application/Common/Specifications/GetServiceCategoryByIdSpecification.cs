using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Common.Specifications;

public class GetServiceCategoryByIdSpecification : Specification<ServiceCategory>
{
    public GetServiceCategoryByIdSpecification(Guid idServiceCategory) 
        : base(spec => spec.IdServiceCategory == idServiceCategory)
    {
        
    }
}