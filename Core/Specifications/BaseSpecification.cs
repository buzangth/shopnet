using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public Expression<Func<T, bool>> Creteria => throw new NotImplementedException();

        public List<Expression<Func<T, object>>> Includes => throw new NotImplementedException();
    }
}