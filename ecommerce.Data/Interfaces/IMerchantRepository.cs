using ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Data.Interfaces
{
    public interface IMerchantRepository
    {
        Task<IEnumerable<Merchant>> GetAllAsync();
        Task<Merchant?> GetByIdAsync(Guid id);
        Task AddAsync(Merchant entity);
        Task UpdateAsync(Merchant entity);
        Task DeleteAsync(Guid id);
        Task<Merchant?> GetByEmailAsync(string email);
    }
}
