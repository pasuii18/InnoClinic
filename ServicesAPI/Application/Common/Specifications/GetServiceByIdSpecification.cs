using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Specifications;

public class GetServiceByIdSpecification : Specification<Service>
{
    public GetServiceByIdSpecification(Guid idService)
         : base(spec => spec.IdService == idService)
    {
        AddInclude(inc => inc.Include(service => service.ServiceCategory));
    }
}