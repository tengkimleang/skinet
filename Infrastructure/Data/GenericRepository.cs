using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interface;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    //Spefice from Class BaseEntity who clase exten from BaseEntity class
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _storeContext;
        public GenericRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _storeContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _storeContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecificationRepository<T> specification)
        {
            return await Applyspcification(specification).ToListAsync();
        }
        public async Task<T> GetEntityBySpecification(ISpecificationRepository<T> specification)
        {
            return await Applyspcification(specification).FirstOrDefaultAsync();
        }
        private IQueryable<T> Applyspcification(ISpecificationRepository<T> specification){
            return SpecificationEvaluator<T>.GetQuery(_storeContext.Set<T>().AsQueryable(),specification);
        }
    }
}