using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interface
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIDAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
    }
}