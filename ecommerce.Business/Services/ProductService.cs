using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using ecommerce.DTOs;
using ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMerchantRepository _merchantRepo;

        public ProductService(IProductRepository productRepo, IMerchantRepository merchantRepo)
        {
            _productRepo = productRepo;
            _merchantRepo = merchantRepo;
        }

        public async Task<ProductDto> CreateProductAsync(ProductCreateDto dto)
        {
            var merchant = await _merchantRepo.GetByIdAsync(dto.MerchantId);
            if (merchant == null)
                throw new InvalidOperationException("Merchant not found");

            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                MerchantId = dto.MerchantId,
                ProductName = dto.ProductName,
                ProductQuantity = dto.ProductQuantity,
                Price = dto.Price
            };

            await _productRepo.AddAsync(product);

            return ToDto(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _productRepo.GetAllAsync();
            return products.Select(p => ToDto(p));
        }

        public async Task<ProductDto?> GetByIdAsync(Guid id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            return product == null ? null : ToDto(product);
        }

        public async Task<IEnumerable<ProductDto>> GetByMerchantIdAsync(Guid merchantId)
        {
            var products = await _productRepo.GetByMerchantIdAsync(merchantId);
            return products.Select(p => ToDto(p));
        }

        public async Task UpdateProductAsync(Guid id, ProductCreateDto dto)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException("Product not found");

            var merchant = await _merchantRepo.GetByIdAsync(dto.MerchantId);
            if (merchant == null) throw new InvalidOperationException("Merchant not found");

            product.MerchantId = dto.MerchantId;
            product.ProductName = dto.ProductName;
            product.ProductQuantity = dto.ProductQuantity;
            product.Price = dto.Price;

            await _productRepo.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null) throw new KeyNotFoundException("Product not found");
            await _productRepo.DeleteAsync(id);
        }

        // Convert Product to ProductDto
        private ProductDto ToDto(Product product) =>
            new ProductDto
            {
                ProductId = product.ProductId,
                MerchantId = product.MerchantId,
                ProductName = product.ProductName,
                ProductQuantity = product.ProductQuantity,
                Price = product.Price,
                IsAvailable = product.IsAvailable
            };
    }
}
