using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecificationRepository<T>
    {
        Expression<Func<T,bool>> criteria {get;}
        List<Expression<Func<T,object>>> Includes {get;}
    }
}