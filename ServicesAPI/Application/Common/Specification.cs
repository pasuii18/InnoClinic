using System.Linq.Expressions;
using Domain;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.Common;

public abstract class Specification<TEntity> 
    where TEntity : BaseEntity
{
    protected Specification() { }

    protected Specification(Expression<Func<TEntity, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<TEntity, bool>>? Criteria { get; }
    public List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>? Includes { get; } 
        = new List<Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>>();
    public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
    public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
    public int? Skip { get; private set; }
    public int? Take { get; private set; }

    protected void AddInclude(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includeExpression)
        => Includes?.Add(includeExpression);
    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        => OrderBy = orderByExpression;
    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        => OrderBy = orderByDescendingExpression;
    protected void AddSkip(int skip) => Skip = skip;
    protected void AddTake(int take) => Take = take;
}