using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Data.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly AppDbContext _db;
        public MerchantRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<Merchant>> GetAllAsync() => await _db.Merchants.ToListAsync();
        public async Task<Merchant?> GetByIdAsync(Guid id) => await _db.Merchants.FindAsync(id);
        public async Task AddAsync(Merchant entity)
        {
            _db.Merchants.Add(entity);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Merchant entity)
        {
            _db.Merchants.Update(entity);
            await _db.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var merchant = await _db.Merchants.FindAsync(id);
            if (merchant != null)
            {
                _db.Merchants.Remove(merchant);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<Merchant?> GetByEmailAsync(string email) => await _db.Merchants.FirstOrDefaultAsync(m => m.Email == email);
    }
}
