using ecommerce.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(Guid id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);

        Task<User?> LoginAsync(string email, string password);
    }
}
