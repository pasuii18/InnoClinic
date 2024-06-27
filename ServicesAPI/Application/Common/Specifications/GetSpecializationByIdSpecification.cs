using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Specifications;

public class GetSpecializationByIdSpecification : Specification<Specialization>
{
    public GetSpecializationByIdSpecification(Guid idSpecialization)
        : base(spec => spec.IdSpecialization == idSpecialization)
    {
        AddInclude(inc => inc.Include(spec => spec.Services).ThenInclude(s => s.ServiceCategory));
    }
}