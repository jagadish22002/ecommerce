using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using ecommerce.Models;
using ecommerce.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ecommerce.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantRepository;

        public MerchantService(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<Merchant> CreateMerchantAsync(MerchantCreateDto dto)
        {
            var existing = await _merchantRepository.GetByEmailAsync(dto.Email);
            if (existing != null)
            {
                throw new InvalidOperationException("Email already registered for a merchant");
            }

            var merchant = new Merchant
            {
                MerchantId = Guid.NewGuid(),
                MerchantName = dto.MerchantName,
                Email = dto.Email,
                MobileNumber = dto.MobileNumber,
                DateOfBirth = DateOnly.FromDateTime(dto.DateOfBirth),
                Location = dto.Location ?? string.Empty,
                Password = dto.Password // in production: store hashed password
            };

            await _merchantRepository.AddAsync(merchant);
            return merchant;
        }

        public async Task<IEnumerable<Merchant>> GetAllMerchantsAsync()
        {
            return await _merchantRepository.GetAllAsync();
        }

        public async Task<Merchant?> GetMerchantByIdAsync(Guid merchantId)
        {
            return await _merchantRepository.GetByIdAsync(merchantId);
        }
    }
}
