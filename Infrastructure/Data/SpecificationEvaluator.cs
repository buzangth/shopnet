using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery,ISpecification<T> spec)
        {
            var query= inputQuery;

            if(spec.Creteria != null)
            {
                query = query.Where(spec.Creteria);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
    }
}