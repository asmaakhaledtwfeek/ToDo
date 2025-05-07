using ToDo.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Persistence.Specifications;

public static class SpecificationEvaluator<TEntity> where TEntity : ValueObject
{
    public static (IQueryable<TEntity> data, int count) GetQuery(
        IQueryable<TEntity> inputQuery,
        Specification<TEntity> specifications)
    {
        IQueryable<TEntity> queryable = inputQuery;

        if (specifications.IsGlobalFiltersIgnored)
            queryable = queryable.IgnoreQueryFilters();

        if (specifications.Criteria is not null)
            queryable = queryable.Where(specifications.Criteria);

        if (specifications.OrderByDescendingExpression.Any())
        {
            IOrderedQueryable<TEntity>? orderedQuery = null;

            foreach (var orderByDesc in specifications.OrderByDescendingExpression)
                orderedQuery = orderedQuery is null
                    ? queryable.OrderByDescending(orderByDesc)
                    : orderedQuery.ThenByDescending(orderByDesc);

            queryable = orderedQuery!;
        }
        else if (specifications.OrderByExpression.Any())
        {
            IOrderedQueryable<TEntity>? orderedQuery = null;

            foreach (var orderBy in specifications.OrderByExpression)
                orderedQuery = orderedQuery is null
                    ? queryable.OrderBy(orderBy)
                    : orderedQuery.ThenBy(orderBy);

            queryable = orderedQuery!;
        }

        if (specifications.IsDistinct)
            queryable = queryable.Distinct();

        int count = specifications.IsTotalCountEnable ? queryable.Count() : 0;

        if (specifications.IsPagingEnabled)
            queryable = queryable.Skip(specifications.Skip).Take(specifications.Take);

        foreach (var include in specifications.Includes)
            queryable = queryable.Include(include);

        queryable = specifications.IsSplitQuery
            ? queryable.AsSplitQuery()
            : queryable.AsSingleQuery();

        return (queryable, count);
    }
}
