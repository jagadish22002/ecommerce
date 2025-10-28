using ecommerce.Data.Models;
using ecommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderCreateDto dto);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId);
        Task DeleteOrderAsync(Guid id);
    }
}
