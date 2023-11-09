﻿using JobResearchSystem.Domain.Entities;
using JobResearchSystem.Infrastructure.Specifications.Contract;
using Microsoft.EntityFrameworkCore;

namespace JobResearchSystem.Infrastructure.Specifications
{
    public static class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria is not null)
                query = query.Where(spec.Criteria);

            if (spec.CriteriaList.Any())
                query = spec.CriteriaList.Aggregate(query, (currentQuery, criteriaExpression) => currentQuery.Where(criteriaExpression));

            if (spec.OrderBy is not null)
                query = query.OrderBy(spec.OrderBy);

            if (spec.OrderByDescending is not null)
                query = query.OrderByDescending(spec.OrderByDescending);

            if (spec.IsPaginationEnabled)
                query = query.Skip(spec.Skip).Take(spec.Take);

            query = spec.Includes.Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));

            return query;
        }
    }
}
