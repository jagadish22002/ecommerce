using ecommerce.Data.Models;

using ecommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(UserCreateDto dto);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid userId);
    }
}
