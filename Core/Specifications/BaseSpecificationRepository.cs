using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecificationRepository<T> : ISpecificationRepository<T>
    {
        public BaseSpecificationRepository()
        {
        }

        public BaseSpecificationRepository(Expression<Func<T, bool>> criteria)
        {
            this.criteria = criteria;
        }

        public Expression<Func<T, bool>> criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;}=new List<Expression<Func<T, object>>>();
        protected void AddInclude(Expression<Func<T,object>> includeExpression){
            Includes.Add(includeExpression);
        }
    }
}