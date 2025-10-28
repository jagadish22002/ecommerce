using ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
    }
}
