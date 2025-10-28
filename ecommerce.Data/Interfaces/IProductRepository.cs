using ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Data.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task AddAsync(Product entity);
        Task UpdateAsync(Product entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Product>> GetAvailableProductsAsync();
        Task<IEnumerable<Product>> GetByMerchantIdAsync(Guid merchantId);
    }
}
