using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _db;

        public OrderRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _db.Orders.Include(o => o.Product).Include(o => o.User).ToListAsync();

        public async Task<Order?> GetByIdAsync(Guid id) =>
            await _db.Orders.Include(o => o.Product).Include(o => o.User)
                            .FirstOrDefaultAsync(o => o.OrderId == id);

        public async Task AddAsync(Order order)
        {
            await _db.Orders.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            _db.Orders.Update(order);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _db.Orders.FindAsync(id);
            if (order != null)
            {
                _db.Orders.Remove(order);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId) =>
            await _db.Orders.Include(o => o.Product)
                            .Include(o => o.User)
                            .Where(o => o.UserId == userId)
                            .ToListAsync();
    }
}
