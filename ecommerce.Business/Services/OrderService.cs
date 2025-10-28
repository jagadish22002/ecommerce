using ecommerce.Data.Interfaces;
using ecommerce.Data.Models;
using ecommerce.DTOs;
using ecommerce.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IUserRepository _userRepo;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository orderRepo, IUserRepository userRepo, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _userRepo = userRepo;
            _productRepo = productRepo;
        }

        public async Task<Order> CreateOrderAsync(OrderCreateDto dto)
        {
            var user = await _userRepo.GetByIdAsync(dto.UserId);
            if (user == null) throw new InvalidOperationException("User not found");

            var product = await _productRepo.GetByIdAsync(dto.ProductId);
            if (product == null) throw new InvalidOperationException("Product not found");

            if (dto.ProductQuantity > product.ProductQuantity)
                throw new InvalidOperationException("Insufficient product quantity");

            // Reduce product quantity
            product.ProductQuantity -= dto.ProductQuantity;
            await _productRepo.UpdateAsync(product);

            var order = new Order
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                ProductName = product.ProductName,
                ProductQuantity = dto.ProductQuantity,
                PaymentStatus = dto.PaymentStatus,
                DeliveryStatus = dto.DeliveryStatus,
                OrderDate = DateTime.UtcNow
            };

            await _orderRepo.AddAsync(order);
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() => await _orderRepo.GetAllAsync();

        public async Task<Order?> GetByIdAsync(Guid id) => await _orderRepo.GetByIdAsync(id);

        public async Task<IEnumerable<Order>> GetByUserIdAsync(Guid userId) => await _orderRepo.GetByUserIdAsync(userId);

        public async Task DeleteOrderAsync(Guid id)
        {
            var order = await _orderRepo.GetByIdAsync(id);
            if (order == null) throw new KeyNotFoundException("Order not found");

            // Restore product quantity
            var product = await _productRepo.GetByIdAsync(order.ProductId);
            if (product != null)
            {
                product.ProductQuantity += order.ProductQuantity;
                await _productRepo.UpdateAsync(product);
            }

            await _orderRepo.DeleteAsync(id);
        }
    }
}
