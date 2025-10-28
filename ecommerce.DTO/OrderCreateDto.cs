using System;
using System.ComponentModel.DataAnnotations;
using ecommerce.Data.Models;

namespace ecommerce.DTOs
{
    public class OrderCreateDto
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int ProductQuantity { get; set; }

        [Required]
        public PaymentStatus PaymentStatus { get; set; }

        [Required]
        public OrderStatus DeliveryStatus { get; set; }
    }
}
