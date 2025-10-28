using ecommerce.Data.Models;
using ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Services.Interfaces
{
    public interface IMerchantService
    {
        Task<Merchant> CreateMerchantAsync(MerchantCreateDto dto);
        Task<IEnumerable<Merchant>> GetAllMerchantsAsync();
        Task<Merchant?> GetMerchantByIdAsync(Guid merchantId);
    }
}
