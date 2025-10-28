using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using ecommerce.DTOs;
using ecommerce.Models;
using ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(UserCreateDto dto)
        {
            // simple business logic: prevent duplicate email
            var existing = await _userRepository.GetByEmailAsync(dto.Email);
            if (existing != null)
            {
                throw new InvalidOperationException("Email already registered");
            }

            var user = new User
            {
                UserId = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email,
                MobileNumber = dto.MobileNumber,
                DateOfBirth = DateOnly.FromDateTime(dto.DateOfBirth),
                Location = dto.Location ?? string.Empty,
                Password = dto.Password // in production: hash the password before saving
            };

            await _userRepository.AddAsync(user);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid userId)
        {
            return await _userRepository.GetByIdAsync(userId);
        }
    }
}
