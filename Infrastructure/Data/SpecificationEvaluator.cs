using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery
        ,ISpecificationRepository<TEntity> specification){
            var query=inputQuery;
            if(specification.criteria !=null){
                query=query.Where(specification.criteria);
            }
            query=specification.Includes.Aggregate(query,(current,include)=> current.Include(include));
            return query;
        }
    }
}