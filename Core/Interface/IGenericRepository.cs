using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interface
{
    public interface IGenericRepository<T> where T : BaseEntity 
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityBySpecification (ISpecificationRepository<T> specification);
        Task<IReadOnlyList<T>> ListAsync(ISpecificationRepository<T> specification);

    }
}