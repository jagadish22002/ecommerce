using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;
        public UserRepository(AppDbContext db) => _db = db;

        public async Task<IEnumerable<User>> GetAllAsync() => await _db.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(Guid id) => await _db.Users.FindAsync(id);

        public async Task AddAsync(User entity)
        {
            _db.Users.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(User entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _db.Users.FindAsync(id);
            if (user != null)
            {
                _db.Users.Remove(user);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByEmailAsync(string email) =>
            await _db.Users.FirstOrDefaultAsync(u => u.Email == email);

        // ✅ New: Login method
        public async Task<User?> LoginAsync(string email, string password)
        {
            // Check if email exists
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
                return null; // User not found

            // For now, simple comparison (you can later use hashing)
            if (user.Password == password)
                return user;

            return null; // Incorrect password
        }
    }
}
