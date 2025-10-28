using ecommerce.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Services.Interfaces
{
    public interface IProductService
    {
        // Create a new product → returns ProductDto
        Task<ProductDto> CreateProductAsync(ProductCreateDto dto);

        // Get all products → returns list of ProductDto
        Task<IEnumerable<ProductDto>> GetAllAsync();

        // Get product by ID → returns ProductDto or null
        Task<ProductDto?> GetByIdAsync(Guid id);

        // Get products by merchant ID → returns list of ProductDto
        Task<IEnumerable<ProductDto>> GetByMerchantIdAsync(Guid merchantId);

        // Update a product
        Task UpdateProductAsync(Guid id, ProductCreateDto dto);

        // Delete a product
        Task DeleteProductAsync(Guid id);
    }
}
