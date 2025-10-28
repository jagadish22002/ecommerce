using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        // Get all products
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        // Get a product by ID
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await _db.Products.FindAsync(id);
        }

        // Add a new product
        public async Task AddAsync(Product entity)
        {
            await _db.Products.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        // Update existing product
        public async Task UpdateAsync(Product entity)
        {
            _db.Products.Update(entity);
            await _db.SaveChangesAsync();
        }

        // Delete a product
        public async Task DeleteAsync(Guid id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }
        }

        // Get available products (Quantity > 0)
        public async Task<IEnumerable<Product>> GetAvailableProductsAsync()
        {
            return await _db.Products
                .Where(p => p.IsAvailable)
                .ToListAsync();
        }

        // ✅ Get products by a specific merchant ID
        public async Task<IEnumerable<Product>> GetByMerchantIdAsync(Guid merchantId)
        {
            return await _db.Products
                .Where(p => p.MerchantId == merchantId)
                .ToListAsync();
        }
    }
}
