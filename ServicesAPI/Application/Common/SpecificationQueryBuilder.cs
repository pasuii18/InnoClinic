using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(this IQueryable<TEntity> inputQuery, 
        Specification<TEntity> specification) 
        where TEntity : BaseEntity
    {
        var query = inputQuery;
        if (specification.Criteria != null) 
            query = query.Where(specification.Criteria);

        if(specification.Includes != null) 
            query = specification.Includes.Aggregate(query, (current, include) 
                => include(current));

        if (specification.OrderBy != null) 
            query = query.OrderBy(specification.OrderBy);
        
        if (specification.OrderByDescending != null) 
            query = query.OrderByDescending(specification.OrderByDescending);
        
        if (specification is { Skip: not null, Take: not null })
            query = query.Skip(specification.Skip.Value).Take(specification.Take.Value);
        
        return query;
    }
}